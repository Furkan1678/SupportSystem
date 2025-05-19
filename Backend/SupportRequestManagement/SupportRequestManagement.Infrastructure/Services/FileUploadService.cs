using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SupportRequestManagement.Infrastructure.Services
{
    public interface IFileUploadService
    {
        Task<string> UploadFileAsync(IFormFile file);
    }

    public class FileUploadService : IFileUploadService
    {
        private readonly string _uploadPath;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FileUploadService(IHttpContextAccessor httpContextAccessor)
        {
            _uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            _httpContextAccessor = httpContextAccessor;

            if (!Directory.Exists(_uploadPath))
            {
                Directory.CreateDirectory(_uploadPath);
            }
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception("Dosya boş veya geçersiz");
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Tam URL oluştur
            var request = _httpContextAccessor.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";
            return $"{baseUrl}/Uploads/{fileName}";
        }
    }
}