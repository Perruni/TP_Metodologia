using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Web_Subasta.Services
{
    public interface ILocalStorageService
    {
        Task<string> UploadAsync(IFormFile file, string folder);
    }
}
