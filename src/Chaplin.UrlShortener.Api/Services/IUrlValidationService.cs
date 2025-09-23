namespace Chaplin.UrlShortener.Api.Services
{
    public interface IUrlValidationService
    {
        bool IsValidUrl(string url);
        bool IsValidCustomCode(string code);
    }
}