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

      
        void IProductoBusiness.AddProducto(Producto producto)
        {
            _repository.AddProducto(producto);
        }

        void DeleteProducto(int ProductoID)
        {
            _repository.DeleteProducto(ProductoID);
        }

        void IProductoBusiness.DeleteProducto(int ProductoID)
        {
            throw new NotImplementedException();
        }

        List<Producto> IProductoBusiness.GetAll()
        {
            return _repository.GetAll();
        }

        public void DuenoProducto(int PrudctoID)
        {
            throw new NotImplementedException();
        }

        public List<Oferta> GetProductoOfertas(int ProductoID)
        {
            throw new NotImplementedException();
        }

        public List<Producto> GetProductoUsuario(int userID)
        {
            throw new NotImplementedException();
        }
    }
}


    