using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Interface
{
     public class IProjectRepository
    {
        public List<Producto> GetAll();
        public void GetProducto(int ProductoID);
        public void AddProducto(Producto producto);
        public void UpdateProducto(Producto producto);
        public void HabilitarProducto(int PrudctoID, int habilitacionProducto);
        public void DeleteProducto(int ProductoID);

     }
}
