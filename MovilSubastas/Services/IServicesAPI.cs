using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace MovilSubastas.Services
{
    public interface IServicesAPI
    {
        Task<Subasta?> GetSubasta(int subastaID);
        Task<List<Subasta>> GetSubastasActivas();
        Task<List<Subasta>> GetSubastasProximas();
        Task<List<Subasta>> GetSubastasFinalizadas();
        Task<Subasta?> GetSubastaProductos(int subastaID);

        Task<Usuario> GetUsuario(int userID);

        Task<Datos_usuario> GetDatosUsuario(int userID);

        Task<Producto> GetProducto(int productoID);

        public Task<Oferta> GetOfertaId(int ofertaID);
        public Task<List<Oferta>> GetOfertasGanadoras(int subastaID);
        public Task<List<Oferta>> GetOfertasUsuario(int usuarioID);
        public Task<int> GetCantidadOfertas(int productoID);



    }
}
