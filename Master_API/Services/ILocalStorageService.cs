using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Master_API.Services
{
    public interface ILocalStorageService
    {
        Task<string> UploadAsync(IFormFile file, string folder);
    }
}
