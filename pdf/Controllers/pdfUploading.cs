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
        [HttpPost]
        public async Task<IActionResult> UploadPdf(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File not selected");
            }
            try
            {
                var filePath = await service.UploadPdfAsync(file);
                return Ok(new { path = filePath });
            }
            catch (Exception ex)
            {

                return BadRequest($"{ex.Message}");
            }

        }
    }
}
