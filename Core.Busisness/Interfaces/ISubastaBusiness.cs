using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Busisness.Interfaces
{
    public interface ISubastaBusiness
    {
        public void AddSubasta (Subasta subastaNueva);
        public Task<List<Subasta>> GetSubastasActivas();
        public Task<List<Subasta>> GetSubastasProximas();
        public Task<List<Subasta>> GetSubastasFinalizadas();
        public Task<Subasta> GetSubastabyID (int id);
        public Task<Subasta> GetSubastaProductos(int id);

        public void UpdateSubasta (Subasta subasta, int subastaID);
        public void HabilitarSubasta(int subastaID, int estadoSubasta);
        public void DeleteSubastabyID (Subasta subasta);

    }
}
