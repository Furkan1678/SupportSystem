using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportRequestManagement.Infrastructure.Services;

namespace SupportRequestManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FileController : ControllerBase
    {
        private readonly IFileUploadService _fileUploadService;

        public FileController(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var fileUrl = await _fileUploadService.UploadFileAsync(file);
            return Ok(new { Url = fileUrl });
        }
    }
}
