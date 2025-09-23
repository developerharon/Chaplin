namespace Chaplin.UrlShortener.Api.DTOs
{
    public class ShortUrlResponse
    {
        public string OriginalUrl { get; set; } = string.Empty;
        public string ShortUrl { get; set; } = string.Empty;
        public string ShortCode { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? ExpiresAt { get; set; }
    }
}