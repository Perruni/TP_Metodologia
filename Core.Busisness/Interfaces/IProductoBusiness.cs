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
        public Producto GetProducto(int ProductoID);
        public void AddProducto(Producto producto);  
        public void UpdateProducto (int habilitacionProducto);
        public void UpdateProducto (Producto producto);
        public void DeleteProducto(int ProductoID);

    }
}
