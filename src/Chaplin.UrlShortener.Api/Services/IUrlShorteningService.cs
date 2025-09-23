using Chaplin.UrlShortener.Api.DTOs;

namespace Chaplin.UrlShortener.Api.Services
{
    public interface IUrlShorteningService
    {
        Task<ShortUrlResponse> CreateShortUrlAsync(CreateShortUrlRequest request, string baseUrl);
        Task<string?> GetOriginalUrlAsync(string shortCode);
        Task<bool> IncrementClickCountAsync(string shortCode);
    }
}