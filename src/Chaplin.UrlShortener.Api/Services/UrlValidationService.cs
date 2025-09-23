using System.Text.RegularExpressions;

namespace Chaplin.UrlShortener.Api.Services
{
    public class UrlValidationService : IUrlValidationService
    {
        private readonly Regex _urlRegex = new Regex(
            @"^https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private readonly Regex _customCodeRegex = new Regex(
            @"^[a-zA-Z0-9\-_]{3,20}$",
            RegexOptions.Compiled);

        public bool IsValidUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return false;

            return Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)
                   && _urlRegex.IsMatch(url);
        }

        public bool IsValidCustomCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return false;

            return _customCodeRegex.IsMatch(code);
        }
    }
}