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

        Task<Producto> IProductoBusiness.AddProducto(Core.Entities.Producto producto)
        {
            var newProducto = _repository.AddProducto(producto);
            return newProducto; 
        }

        Task<Producto> IProductoBusiness.DeleteProducto(int ProductoID)
        {
            var deleteProducto = _repository.DeleteProducto(ProductoID);
            return deleteProducto;
        }

        Task<Producto> IProductoBusiness.CancelarProducto(Producto producto)
        {
            return _repository.CancelarProducto(producto);
        }

        Task<Producto> IProductoBusiness.DatosProducto(int productoID)
        {
            return _repository.DatosProducto(productoID);
        }

        Task<List<Producto>> IProductoBusiness.GetAll()
        {
            return _repository.GetAll();
        }    
        
        Task<Producto> IProductoBusiness.GetProducto(int ProductoID)
        {
            return _repository.GetProducto(ProductoID);
        }

        Task<List<Oferta>> IProductoBusiness.GetProductoOfertas(int ProductoID)
        {
            throw new NotImplementedException();
        }

        Task<List<Producto>> IProductoBusiness.GetProductoUsuario(int userID)
        {
            throw new NotImplementedException();
        }
    }
}


    