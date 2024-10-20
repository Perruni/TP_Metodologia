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

        public Task<Producto> DatosProducto(int productoID)
        {
            var DatosProducto =  _dbContext.Productos.Where(p => p.productoID == productoID)
                                .Include(u => u.Usuario.DatosUsuario)                                
                                .FirstOrDefaultAsync();

            return DatosProducto;
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

        public async Task<Producto> CancelarProducto(Producto producto)
        {
            _dbContext.Update(producto);
            await _dbContext.SaveChangesAsync();

            return producto;

        }


        #endregion

        #region SUBASTA

        #endregion

        #region DATOS_USUARIO

        public Task<Datos_usuario> DatosUsuario(int userID)
        {
            var DatosUsuario = _dbContext.DatosUsuario.Where(u => u.usuarioID == userID)                                
                                .FirstOrDefaultAsync();

            return DatosUsuario;
        }

        public async Task<Datos_usuario> AddDatosUsuario(Datos_usuario datosUsuario)
        {
            _dbContext.Add(datosUsuario);
            await _dbContext.SaveChangesAsync();

            return datosUsuario;

        }

        #endregion
    }
}
