using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pdf.Sevices.FileUploadservices;

namespace pdf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pdfUploadingController: ControllerBase
    {
        private readonly IFileUploadService service;

        public pdfUploadingController(IFileUploadService _service)
        {
            this.service = _service;
        }
        [HttpPost("UploadPdf")]
        public async Task<IActionResult> UploadPdf(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File not selected");
            }
            try
            {
                var relativePath = await service.UploadPdfAsync(file);

                // Base URL generate karna
                var baseUrl = $"{Request.Scheme}://{Request.Host}";

                // Full URL combine karna
                var fullUrl = baseUrl + relativePath;

                return Ok(new { path = fullUrl });
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

    }
}
