using Core.Data.Interface;
using Core.Entities;
using Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Core.Data
{
    
    public class ProjectRepository : IProjectRepository
    {
        private readonly TPI_DbContext _dbContext;
        public ProjectRepository(TPI_DbContext dbContext) // Solo necesita el contexto ahora
        {
            _dbContext = dbContext;
        }

        #region PORDUCTO
        public void AddProducto(Producto producto)
        {
            _dbContext.Add(producto);
            _dbContext.SaveChanges();
        }

        public void DeleteProducto(int productoID)
        {
            var producto = _dbContext.Productos.Find(productoID);
            if (producto != null)
            {
                _dbContext.Remove(producto);
                _dbContext.SaveChanges();
            }
        }

        public void DuenoProducto(int productoID)
        {
            _dbContext.Productos.Where(p => p.productoID == productoID)
                                .Include(u => u.datosUsuario)
                                .FirstOrDefault();
        }

        public List<Producto> GetAll()
        {
            return _dbContext.Productos.ToList();
        }

        public void GetProducto(int productoID)
        {
            throw new NotImplementedException();
        }

        public List<Oferta> GetProductoOfertas(int productoID)
        {
            throw new NotImplementedException();
        }

        public List<Producto> GetProductoUsuario(int userID)
        {
            throw new NotImplementedException();
        }

        public void HabilitarProducto(int productoID, int habilitacionProducto)
        {
            throw new NotImplementedException();
        }

        public void UpdateProducto(Producto producto)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
