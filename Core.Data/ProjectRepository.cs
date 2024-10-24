using Core.Data.Interface;
using Core.Entities;
using Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static Core.Entities.Oferta;

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

        public Task<List<Producto>> GetProductos()
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
            var productoUsuario = _dbContext.Productos.Where(p => p.usuarioID == userID)
                                                            .ToListAsync();

            return productoUsuario;
        }

        public Task<Producto> HabilitarProducto(int PrudctoID, int habilitacionProducto)
        {
            throw new NotImplementedException();
        }

        public async Task<Producto> UpdateProducto(Producto producto)
        {
            _dbContext.Update(producto);
            await _dbContext.SaveChangesAsync();

            return producto;
        }

        public async Task<Producto> CancelarProducto(Producto producto)
        {
            _dbContext.Update(producto);
            await _dbContext.SaveChangesAsync();

            return producto;

        }


        #endregion

        #region OFERTAS

        public async Task<Oferta> AddOferta(Oferta oferta)
        {
            _dbContext.Add(oferta);
            await _dbContext.SaveChangesAsync();

            return oferta;
        }

        public async Task<Oferta> UpdateOferta(Oferta oferta)
        {
            _dbContext.Update(oferta);
            await _dbContext.SaveChangesAsync();

            return oferta;
        }


        public async Task<Oferta> DeleteOferta(int ofertaID)
        {
            var oferta = _dbContext.Ofertas.Find(ofertaID);
            if (oferta != null)
            {
                _dbContext.Remove(oferta);
                await _dbContext.SaveChangesAsync();

                return oferta;
            }
            return null;
        }

        public Task<List<Oferta?>> GetOfertasGanadoras(int subastaID)
        {
            var ofertasGanadoras = _dbContext.Ofertas
                .Where(o => o.estadoOferta == EstadoOferta.Ganadora &&
                            o.producto != null &&
                            o.producto.subastaID == subastaID)
                .GroupBy(o => o.productoID)
                .Select(g => g
                    .OrderByDescending(o => o.montoOferta)
                    .ThenBy(o => o.fechaOferta)
                    .FirstOrDefault())
                .ToListAsync();

            return ofertasGanadoras;

        }

        public Task<Oferta> GetOfertaId(int ofertaID)
        {
            var oferta = _dbContext.Ofertas.Where(o => o.ofertaID == ofertaID).FirstOrDefaultAsync();

            return oferta;
        }

        public Task<Oferta> GetOfertaGanadora(int productoID)
        {
            var oferGanadora = _dbContext.Ofertas.Where(o => o.productoID == productoID && o.estadoOferta == EstadoOferta.Ganadora)
                .FirstOrDefaultAsync();

            return oferGanadora;               

        }

        public Task<List<Oferta>> GetOfertasUsuario(int userID)
        {
            var oferUsuario = _dbContext.Ofertas.Where(o => o.usuarioID == userID)
                .ToListAsync();

            return oferUsuario;
        }        

        public Task<List<Oferta>> GetTodasLasOfertas()
        {
            var ofertas = _dbContext.Ofertas.ToListAsync();

            return ofertas;
        }

        public Task<int> GetCantidadOfertas(int productoID)
        {
            var cantidadDeOfertas =  _dbContext.Ofertas
                                            .Where(o => o.productoID == productoID)
                                            .CountAsync();

            return cantidadDeOfertas;
        }

        #endregion

        #region SUBASTA

        public async Task<Subasta> AddSubasta(Subasta subasta)
        {
            _dbContext.Add(subasta);
            await _dbContext.SaveChangesAsync();

            return subasta;
        }

        public async Task<Subasta> UpdateSubasta(Subasta subasta)
        {
            _dbContext.Update(subasta);
            await _dbContext.SaveChangesAsync();

            return subasta;
        }

        public Task<Subasta?> GetSubasta(int subastaID)
        {
           var subasta = _dbContext.Subastas.Where(s => s.subastaID == subastaID).FirstOrDefaultAsync();

           return subasta;

        }

        public Task<List<Subasta>> GetSubastasActivas()
        {
            var subastasActivas = _dbContext.Subastas.Where(s => s.estadoSubasta == Subasta.EstadoSubasta.Activa)
                                                     .ToListAsync();

            return subastasActivas;

        }

        public Task<List<Subasta>> GetSubastasProximas()
        {
            var subastasProximas = _dbContext.Subastas.Where(s => s.estadoSubasta == Subasta.EstadoSubasta.Proxima)
                                                    .ToListAsync();

            return subastasProximas;
        }

        public Task<List<Subasta>> GetSubastasFinalizadas()
        {
            var subastasFinalizadas = _dbContext.Subastas.Where(s => s.estadoSubasta == Subasta.EstadoSubasta.Finalizadas || s.estadoSubasta == Subasta.EstadoSubasta.Deshabilitado)
                                                    .ToListAsync();

            return subastasFinalizadas;
        }

        public Task<Subasta?> GetSubastaProductos(int subastaID)
        {
            var subastaProductos = _dbContext.Subastas.Where(s => s.subastaID == subastaID)
                                                      .Include(p => p.listaProductos)
                                                      .FirstOrDefaultAsync();
            return subastaProductos;
        }


        #endregion

        #region DATOS_USUARIO

        public Task<Datos_usuario> GetDatosUsuario(int userID)
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

        #region USUARIO

        public async Task<Usuario> AddUsuario(Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public Task<Usuario> GetUsuario(int userID)
        {
            var usuario = _dbContext.Usuarios.Where(u => u.usuarioID == userID)
                .FirstOrDefaultAsync();

            return usuario;
        }

        public async Task<Usuario> UpdateUsuario(Usuario usuario)
        {
            _dbContext.Update(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> Deleteusuario(int userID)
        {
            var usuario = _dbContext.Usuarios.Find(userID);
            if (usuario != null)
            {
                _dbContext.Remove(usuario);
                await _dbContext.SaveChangesAsync();

                return usuario;
            }
            return null; 
        }

        public Task<List<Usuario>> GetUsuarios()
        {
            var usuarios = _dbContext.Usuarios.ToListAsync();

            return usuarios;
        }


        #endregion
    }
}
