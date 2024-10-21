using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Busisness.Interfaces
{
    public interface IOfertaBussiness
    {
        public Task<Oferta> ObtenerOfertaPorId(int ofertaID);
        public Task<Oferta> ObtenerOfertaGanadora(int porductoID);
        public Task<List<Oferta>> ObtenerOfertasPendientes(int productoID);
        public Task<List<Oferta>> ObtenerOfertasNoGanadoras(int productoID);
        public Task<List<Oferta>> ObtenerOfertasGanadoras();
        public Task<List<Oferta>> GetProductoOfertas(int ProductoID);
        public Task<List<Oferta>> ObtenerTodasLasOfertas();
        public Task<Oferta> AddOferta(Oferta oferta);
        public Task<Oferta> EliminarOferta(int id);

    }
}
