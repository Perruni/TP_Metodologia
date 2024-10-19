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


        public async Task<Producto> AddProducto(Producto producto)
        {
            var newProducto = await _repository.AddProducto(producto);
            return newProducto; 
        }

        public async Task<Producto> DeleteProducto(int ProductoID)
        {
            var deleteProducto = await _repository.DeleteProducto(ProductoID);
            return deleteProducto;
        }

        Task<List<Producto>> IProductoBusiness.GetAll()
        {
            return _repository.GetAll();
        }
        
        public List<Oferta> GetProductoOfertas(int ProductoID)
        {
            throw new NotImplementedException();
        }

        public List<Producto> GetProductoUsuario(int userID)
        {
            throw new NotImplementedException();
        }

        Task<List<Oferta>> IProductoBusiness.GetProductoOfertas(int ProductoID)
        {
            throw new NotImplementedException();
        }

        Task<List<Producto>> IProductoBusiness.GetProductoUsuario(int userID)
        {
            throw new NotImplementedException();
        }

        Task<Producto> IProductoBusiness.DuenoProducto(int productoID)
        {
            throw new NotImplementedException();
        }

        Task<Producto> IProductoBusiness.GetProducto(int ProductoID)
        {
            return _repository.GetProducto(ProductoID);
        }
    }
}


    