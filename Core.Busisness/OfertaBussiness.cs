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
    
    public class OfertaBusiness : IOfertaBussiness
    {
        private readonly IProjectRepository _repository;

        public OfertaBusiness(IProjectRepository Repository)
        {
            _repository = Repository;
        }

        public Task<Oferta> AddOferta(Oferta oferta)
        {
            return _repository.AddOferta(oferta);
        }

        public Task<Oferta> UpdateOferta(Oferta oferta)
        {
            throw new NotImplementedException();
        }

        public Task<Oferta> DeleteOferta(int ofertaID)
        {
            return _repository.DeleteOferta(ofertaID);
        }

        public Task<int> GetCantidadOfertas(int productoID)
        {
            return _repository.GetCantidadOfertas(productoID);
        }

        public Task<Oferta> GetOfertaGanadora(int porductoID)
        {
            return _repository.GetOfertaGanadora(porductoID);
        }

        public Task<Oferta> GetOfertaId(int ofertaID)
        {
            return _repository.GetOfertaId(ofertaID);
        }

        public Task<List<Oferta>> GetOfertasGanadoras(int subastaID)
        {
            return _repository.GetOfertasGanadoras(subastaID);
        }

        public Task<List<Oferta>> GetOfertasUsuario(int usuarioID)
        {
            return _repository.GetOfertasUsuario(usuarioID);
        }

        public Task<List<Oferta>> GetProductoOfertas(int productoID)
        {
            return _repository.GetProductoOfertas(productoID);
        }

        public Task<List<Oferta>> GetTodasLasOfertas()
        {
            return _repository.GetTodasLasOfertas();
        }

    }
}
