using Chaplin.UrlShortener.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chaplin.UrlShortener.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class RedirectController : ControllerBase
    {
        private readonly IUrlShorteningService _urlShorteningService;

        public RedirectController(IUrlShorteningService urlShorteningService)
        {
            _urlShorteningService = urlShorteningService;
        }

        [HttpGet("{shortCode}")]
        public async Task<IActionResult> RedirectToOriginalUrl(string shortCode)
        {
            var originalUrl = await _urlShorteningService.GetOriginalUrlAsync(shortCode);

            if (string.IsNullOrEmpty(originalUrl))
            {
                return NotFound(new { error = "Short URL not found or expired" });
            }

            // Increment click count asynchronously (fire and forget)
            _ = Task.Run(() => _urlShorteningService.IncrementClickCountAsync(shortCode));

            return Redirect(originalUrl);
        }
    }
}