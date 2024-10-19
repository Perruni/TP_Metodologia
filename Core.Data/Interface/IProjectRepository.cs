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

        public Task<List<Producto>> GetAll();
        public Task<List<Oferta>> GetProductoOfertas(int ProductoID);
        public Task<List<Producto>> GetProductoUsuario(int userID);
        public Task<Producto> GetProducto(int ProductoID);
        public Task<Producto> AddProducto(Producto producto);
        public Task<Producto> UpdateProducto(Producto producto);
        public Task<Producto> HabilitarProducto(int PrudctoID, int habilitacionProducto);
        public Task<Producto> DeleteProducto(int ProductoID);
        public Task<Producto> DuenoProducto(int productoID);




    }
}
