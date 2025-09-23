using Chaplin.UrlShortener.Api.DTOs;
using Chaplin.UrlShortener.Api.Models;
using Chaplin.UrlShortener.Api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Chaplin.UrlShortener.Api.Services
{
    public class UrlShorteningService : IUrlShorteningService
    {
        private readonly ShortenedUrlDbContext _context;
        private readonly IUrlValidationService _validationService;

        public UrlShorteningService(ShortenedUrlDbContext dbContext, IUrlValidationService validationService)
        {
            _context = dbContext;
            _validationService = validationService;
        }

        public async Task<ShortUrlResponse> CreateShortUrlAsync(CreateShortUrlRequest request, string baseUrl)
        {
            if (!_validationService.IsValidUrl(request.OriginalUrl))
            {
                throw new ArgumentException("Invalid URL format");
            }

            // Check if URL already exists (optional optimization)
            var existingUrl = await _context.ShortenedUrls
                .FirstOrDefaultAsync(u => u.OriginalUrl == request.OriginalUrl && u.IsActive);

            if (existingUrl != null)
            {
                return new ShortUrlResponse
                {
                    OriginalUrl = existingUrl.OriginalUrl,
                    ShortCode = existingUrl.ShortCode,
                    ShortUrl = $"{baseUrl.TrimEnd('/')}/{existingUrl.ShortCode}",
                    CreatedAt = existingUrl.Created,
                    ExpiresAt = existingUrl.ExpiresAt
                };
            }

            var shortCode = !string.IsNullOrEmpty(request.CustomCode)
                ? request.CustomCode
                : await GenerateUniqueShortCodeAsync();

            // Check if custom code already exists
            if (await _context.ShortenedUrls.AnyAsync(u => u.ShortCode == shortCode))
            {
                throw new InvalidOperationException("Short code already exists");
            }

            var shortenedUrl = new ShortenedUrl
            {
                OriginalUrl = request.OriginalUrl,
                ShortCode = shortCode,
                ExpiresAt = request.ExpiresAt
            };

            _context.ShortenedUrls.Add(shortenedUrl);
            await _context.SaveChangesAsync();

            return new ShortUrlResponse
            {
                OriginalUrl = shortenedUrl.OriginalUrl,
                ShortCode = shortenedUrl.ShortCode,
                ShortUrl = $"{baseUrl.TrimEnd('/')}/{shortenedUrl.ShortCode}",
                CreatedAt = shortenedUrl.Created,
                ExpiresAt = shortenedUrl.ExpiresAt
            };
        }

        public async Task<string?> GetOriginalUrlAsync(string shortCode)
        {
            var shortenedUrl = await _context.ShortenedUrls
            .FirstOrDefaultAsync(u => u.ShortCode == shortCode && u.IsActive);

            if (shortenedUrl == null)
                return null;

            // Check if expired
            if (shortenedUrl.ExpiresAt.HasValue && shortenedUrl.ExpiresAt.Value < DateTime.UtcNow)
                return null;

            return shortenedUrl.OriginalUrl;
        }

        public async Task<bool> IncrementClickCountAsync(string shortCode)
        {
            var shortenedUrl = await _context.ShortenedUrls
            .FirstOrDefaultAsync(u => u.ShortCode == shortCode && u.IsActive);

            if (shortenedUrl == null)
                return false;

            shortenedUrl.ClickCount++;
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<string> GenerateUniqueShortCodeAsync()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            string shortCode;

            do
            {
                shortCode = new string(Enumerable.Repeat(chars, 6)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            while (await _context.ShortenedUrls.AnyAsync(u => u.ShortCode == shortCode));

            return shortCode;
        }

    }
}
