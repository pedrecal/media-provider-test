using System.IO;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Take.Api.Media.Provider.Controllers
{
    /// <summary>
    /// Files handling controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        /// <summary>
        /// Get document
        /// </summary>
        /// <param name="bearer">Used in AuthFilter</param>
        /// <param name="document"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{document}")]
        public async Task<IActionResult> GetDocumentAsync(
        [FromHeader(Name = "bearer")] string bearer,
        [FromRoute(Name = "document")] string document,
        CancellationToken cancellationToken)
        {
            if (bearer == "potato" && new FileExtensionContentTypeProvider().TryGetContentType(document, out var mimeType))
            {
                return File(new FileStream(Path.Combine("D:/storage", document), FileMode.Open, FileAccess.Read), mimeType);
            }
            return NoContent();
        }
    }
}
