using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Core.Shared.Enum;

namespace BlobImagesTest.Services
{
    public class AzureBlobStorageService : IAzureBlobStorageService
    {

        private readonly string azureStorageConnectionString;

        public AzureBlobStorageService(IConfiguration configuration)
        {
            this.azureStorageConnectionString = configuration.GetValue<string>("AzureBlobStorageConnection");
        }

        public async Task DeleteAsync(Container container, string blobFilename)
        {
            var containerName = Enum.GetName(typeof(Container), container).ToLower();
            var blobContainerClient = new BlobContainerClient(this.azureStorageConnectionString, containerName);
            var blobClient = blobContainerClient.GetBlobClient(blobFilename);

            try
            {
                await blobClient.DeleteAsync();
            }
            catch
            {
                Console.WriteLine("se produjo un error");
                throw;
            }
        }

        public async Task<string> UploadAsync(IFormFile file, Container container)
        {
            if (file.Length == 0) return null;
            var containerName = Enum.GetName(typeof(Container), container).ToLower();
            var blobContainerClient = new BlobContainerClient(this.azureStorageConnectionString, containerName);            
            var blobName = Guid.NewGuid().ToString();
            

            var blobClient = blobContainerClient.GetBlobClient(blobName);
            var blobHttpHeader = new BlobHttpHeaders { ContentType = file.ContentType };

            await using (Stream stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, new BlobUploadOptions { HttpHeaders = blobHttpHeader });
            }
            return blobName;
        }

    }

    public interface IAzureBlobStorageService
    {
        Task<string> UploadAsync(IFormFile file, Container container);
        Task DeleteAsync(Container container, string blobFilename);
    }
}
