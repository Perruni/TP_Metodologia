using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Busisness.Interfaces
{
    public interface IProductoBusiness
    {
        public Task<Producto> GetProducto(int productoID);
        public Task<Producto> AddProducto(Producto producto);
        public Task<Producto> UpdateProducto(Producto producto);
        public Task<Producto> HabilitarProducto(int productoID, int habilitacionProducto);
        public Task<Producto> DeleteProducto(int productoID);
        public Task<Producto> DatosProducto(int productoID);
        public Task<Producto> CancelarProducto(Producto producto);
        public Task<List<Producto>> GetProductoUsuario(int userID);
        public Task<List<Producto>> GetProductos();

    }
}
