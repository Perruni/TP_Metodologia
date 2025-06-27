using Master_API.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Master_API.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private readonly IWebHostEnvironment _environment;

        public LocalStorageService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> UploadAsync(IFormFile file, string folder)
        {
            var uploadsPath = Path.Combine(_environment.WebRootPath, folder);

            if (!Directory.Exists(uploadsPath))
            {
                Directory.CreateDirectory(uploadsPath);
            }

            var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsPath, uniqueName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Path.Combine("/", folder, uniqueName).Replace("\\", "/");
        }
    }
}
