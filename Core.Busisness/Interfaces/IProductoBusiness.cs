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
        public Task<List<Producto>> GetAll();
        public Task<List<Producto>> GetProductoUsuario(int userID);
        public Task<Producto> GetProducto(int ProductoID);
        public Task<Producto> AddProducto(Producto producto);
        //public void UpdateProducto(Producto producto);
        //public void HabilitarProducto(int PrudctoID, int habilitacionProducto);
        public Task<Producto> DeleteProducto(int ProductoID);
        public Task<Producto> CancelarProducto(Producto producto);


    }
}
