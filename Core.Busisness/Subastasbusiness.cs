using Core.Busisness.Interfaces;
using Core.Data.Interface;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Busisness
{
    public class Subastasbusiness : ISubastaBusiness
    {
        private readonly IProjectRepository _repository;

        public Subastasbusiness(IProjectRepository Repository)
        {
            _repository = Repository;
        }
        public Task<Subasta> AddSubasta(Subasta subasta)
        {
            return _repository.AddSubasta(subasta);
        }

        public Task<Subasta?> GetSubasta(int subastaID)
        {
            return _repository.GetSubasta(subastaID);
        }

        public Task<Subasta?> GetSubastaProductos(int subastaID)
        {
            return _repository.GetSubastaProductos(subastaID);
        }

        public Task<List<Subasta>> GetSubastasActivas()
        {
            return _repository.GetSubastasActivas();
        }

        public Task<List<Subasta>> GetSubastasFinalizadas()
        {
            return _repository.GetSubastasFinalizadas();
        }

        public Task<List<Subasta>> GetSubastasProximas()
        {
            return _repository.GetSubastasProximas();
        }

        public Task<Subasta> UpdateSubasta(Subasta subasta)
        {
            return _repository.UpdateSubasta(subasta);
        }
    }
}
