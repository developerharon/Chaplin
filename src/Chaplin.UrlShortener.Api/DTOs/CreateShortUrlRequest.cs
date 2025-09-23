namespace Chaplin.UrlShortener.Api.DTOs
{
    public record CreateShortUrlRequest(string OriginalUrl, DateTimeOffset? ExpiresAt, string? CustomCode);
}