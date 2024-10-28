using Core.Entities;
using Core.Shared.DTOs;
using Core.Shared.DTOs.Producto;
using Core.Shared.DTOs.Oferta;
using Core.Shared.DTOs.Usuario;
using Core.Shared.DTOs.Subastas;

namespace Web_Subasta.Services
{
    public interface IServiceAPI
    {
        Task<Subasta?> GetSubasta(int subastaID);
        Task<List<Subasta>> GetSubastasActivas();
        Task<List<Subasta>> GetSubastasProximas();
        Task<List<Subasta>> GetSubastasFinalizadas();
        Task<Subasta?> GetSubastaProductos(int subastaID);

        Task<Usuario> AddUsuario(Usuario usuario);
        Task<Usuario> GetUsuario(int userID);
        Task<Usuario> UpdateUsuario(Usuario usuario, int userID);
        Task<Usuario> Deleteusuario(int userID);

        Task<Datos_usuario> GetDatosUsuario(int userID);
        Task<Datos_usuario> AddDatosUsuario(Datos_usuarioDTO datosUsuario, int userID);

        Task<Producto> GetProducto(int productoID);
        Task<Producto> AddProducto(ProductoDTO producto, int userID, int subastaID);
        Task<Producto> CancelarProducto(int userID, int productoID);
        Task<List<Producto>> GetProductoUsuario(int userID);

        public Task<OfertaDTO> AddOferta(OfertaDTO oferta,int userID, int productoID);
        public Task<Oferta> UpdateOferta(Oferta oferta, int userID, int ofertaID);
        public Task<Oferta> DeleteOferta(int userID, int ofertaID);
        public Task<Oferta> GetOfertaId(int ofertaID);
        public Task<List<Oferta>> GetOfertasGanadoras(int subastaID);
        public Task<List<Oferta>> GetOfertasUsuario(int usuarioID);
        public Task<int> GetCantidadOfertas(int productoID);

    }
}
