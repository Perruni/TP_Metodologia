using Core.Busisness.Interfaces;
using Core.Data.Interface;
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
        private readonly IProjectRepository _repository;

        public ProductoBusiness(IProjectRepository Repository) {
            _repository = Repository;
        }

        public Task<Producto> AddProducto(Producto producto)
        {
            return _repository.AddProducto(producto);
        }

        public Task<Producto> CancelarProducto(Producto producto)
        {
            return _repository.CancelarProducto(producto);
        }

        public Task<Producto> DatosProducto(int productoID)
        {
            return _repository.DatosProducto(productoID);
        }

        public Task<Producto> DeleteProducto(int productoID)
        {
            return _repository.DeleteProducto(productoID);
        }

        public Task<Producto> GetProducto(int productoID)
        {
            return _repository.GetProducto(productoID);
        }

        public Task<List<Producto>> GetProductos()
        {
            return _repository.GetProductos();
        }

        public Task<List<Producto>> GetProductoUsuario(int userID)
        {
            return _repository.GetProductoUsuario(userID);
        }

        public Task<Producto> HabilitarProducto(int productoID, int habilitacionProducto)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> UpdateProducto(Producto producto)
        {
            return _repository.UpdateProducto(producto);
        }
    }
}


    