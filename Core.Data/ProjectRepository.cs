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
        public async Task<Producto> AddProducto(Producto producto)
        {
            _dbContext.Add(producto);
            await _dbContext.SaveChangesAsync();

             return producto;
           
        }

        public async Task<Producto> DeleteProducto(int productoID)
        {
            var producto = _dbContext.Productos.Find(productoID);
            if (producto != null)
            {
                _dbContext.Remove(producto);
                await _dbContext.SaveChangesAsync();

                return producto;
            }
            return null;
        }

        public Task<Producto> DuenoProducto(int productoID)
        {
            var DuenoProducto =  _dbContext.Productos.Where(p => p.productoID == productoID)
                                .Include(u => u.Usuario.DatosUsuario)                                
                                .FirstOrDefaultAsync();

            return DuenoProducto;
        }

        public Task<List<Producto>> GetAll()
        {
            return _dbContext.Productos.ToListAsync();
        }

        public Task<Producto> GetProducto(int productoID)
        {
            var producto = _dbContext.Productos.Where(p => p.productoID == productoID).FirstOrDefaultAsync();

            return producto;
        }

        public Task<List<Oferta>> GetProductoOfertas(int productoID)
        {
            var ofertas =  _dbContext.Ofertas.Where(p => p.productoID == productoID)                                                    
                                                   .ToListAsync();

            return ofertas;

        }

        public Task<List<Producto>> GetProductoUsuario(int userID)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> HabilitarProducto(int PrudctoID, int habilitacionProducto)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> UpdateProducto(Producto producto)
        {
            throw new NotImplementedException();
        }
          


        #endregion

        #region SUBASTA

        #endregion
    }
}
