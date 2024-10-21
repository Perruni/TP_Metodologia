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
        public Task<Subasta> AddSubasta(Subasta subasta);
        public Task<Subasta> UpdateSubasta(Subasta subasta);
        public Task<Subasta?> GetSubasta(int subastaID);
        public Task<List<Subasta>> GetSubastasActivas();
        public Task<List<Subasta>> GetSubastasProximas();
        public Task<List<Subasta>> GetSubastasFinalizadas();
        public Task<Subasta?> GetSubastaProductos(int subastaID);

    }
}
