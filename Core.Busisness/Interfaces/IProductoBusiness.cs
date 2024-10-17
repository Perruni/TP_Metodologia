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
        public List<Producto> GetAll();
        public List<Oferta> GetProductoOfertas(int ProductoID);
        public List<Producto> GetProductoUsuario(int userID);
        //public void GetProducto(int ProductoID);
        public void AddProducto(Producto producto);
        //public void UpdateProducto(Producto producto);
        //public void HabilitarProducto(int PrudctoID, int habilitacionProducto);
        public void DeleteProducto(int ProductoID);
        public void DuenoProducto(int PrudctoID);

    }
}
