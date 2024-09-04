using Core.Busisness.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Busisness
{
    public class ProductoBusiness : IProductoBusiness
    {

        public ProductoBusiness(IRepository Repository) {
            -repository = Repository;
        }
        void AddProducto(Producto producto)
        {
            -repository.AddProducto(producto)
        }

        void DeleteProducto(int ProductoID)
        {
            -repository.DeleteProducto(ProductoID);
        }

        List<Producto> GetAll()
        {
            -repository.GetAll();
        }

        Producto GetProducto(int ProductoID)
        {
            -repository.GetProducto(ProductoID);
        }

        void UpdateProducto(int habilitacionProducto)
        {
            -repository.UpdateProducto(habilitacionProducto);
        }

        void UpdateProducto(Producto producto)
        {
            -repository.UpdateProducto(producto);
        }
    }
}
