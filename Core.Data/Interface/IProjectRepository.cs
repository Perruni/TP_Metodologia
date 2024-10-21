using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Interface
{
    public interface IProjectRepository
    {

        public Task<Oferta> AddOferta(Oferta oferta);
        public Task<List<Oferta>> GetProductoOfertas(int ProductoID);
        public Task<List<Oferta>> GetOfertasGanadoras(int subastaID);
        public Task<List<Producto>> GetProductoUsuario(int userID);
        public Task<List<Producto>> GetAll();
        public Task<Producto> GetProducto(int ProductoID);
        public Task<Producto> AddProducto(Producto producto);
        public Task<Producto> UpdateProducto(Producto producto);
        public Task<Producto> HabilitarProducto(int PrudctoID, int habilitacionProducto);
        public Task<Producto> DeleteProducto(int ProductoID);
        public Task<Producto> DatosProducto(int productoID);
        public Task<Producto> CancelarProducto(Producto producto);
        public Task<Datos_usuario> GetDatosUsuario(int userID);
        public Task<Datos_usuario> AddDatosUsuario(Datos_usuario datosUsuario);
        public Task<Subasta> AddSubasta (Subasta subasta);
        public Task<Subasta> UpdateSubasta(Subasta subasta);
        public Task<Subasta?> GetSubasta(int subastaID);
        public Task<List<Subasta>> GetSubastasActivas();
        public Task<List<Subasta>> GetSubastasProximas();
        public Task<List<Subasta>> GetSubastasFinalizadas();
        public Task<Subasta?> GetSubastaProductos(int subastaID);
    }
}
