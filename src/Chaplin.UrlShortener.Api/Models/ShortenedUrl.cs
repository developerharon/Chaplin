namespace Chaplin.UrlShortener.Api.Models
{
    public class ShortenedUrl : EntityBase
    {
        public string OriginalUrl { get; set; } = string.Empty;
        public string ShortCode { get; set; } = string.Empty;
        public DateTimeOffset? ExpiresAt { get; set; }
        public int ClickCount { get; set; } = 0;
        public bool IsActive { get; set; } = true;
    }
}