using Core.Entities;

namespace Master_API.Services.Interfaces
{
    public interface ISubastaService
    {
        Task<List<Subasta>> GetSubastasToCloseAsync(DateTime currentTime);
        Task<List<Subasta>> GetSubastasToOpenAsync(DateTime currentTime);
        Task CloseSubastaAsync(Subasta subasta);
        Task OpenSubastaAsync(Subasta subasta);

        



    }
}
