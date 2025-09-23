using Chaplin.UrlShortener.Api.DTOs;
using Chaplin.UrlShortener.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chaplin.UrlShortener.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly IUrlShorteningService _urlShorteningService;

        public UrlController(IUrlShorteningService urlShorteningService)
        {
            _urlShorteningService = urlShorteningService;
        }

        [HttpPost("shorten")]
        public async Task<ActionResult<ShortUrlResponse>> ShortenUrl([FromBody] CreateShortUrlRequest request)
        {
            try
            {
                var baseUrl = $"{Request.Scheme}://{Request.Host}";
                var result = await _urlShorteningService.CreateShortUrlAsync(request, baseUrl);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred" });
            }
        }
    }
}