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
        public Task<Oferta> AddOferta(Oferta oferta);
        public Task<Oferta> UpdateOferta(Oferta oferta);
        public Task<Oferta> DeleteOferta(int ofertaID);
        public Task<Oferta> GetOfertaId(int ofertaID);
        public Task<Oferta> GetOfertaGanadora(int porductoID);
        public Task<List<Oferta>> GetOfertasGanadoras(int subastaID);
        public Task<List<Oferta>> GetOfertasUsuario(int usuarioID);
        public Task<List<Oferta>> GetProductoOfertas(int productoID);
        public Task<List<Oferta>> GetTodasLasOfertas();
        public Task<int> GetCantidadOfertas(int productoID);


    }
}
