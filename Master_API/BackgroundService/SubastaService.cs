using Core.Data;
using Core.Entities;
using Master_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Master_API.Services
{
    public class SubastaService : ISubastaService
    {
        private readonly TPI_DbContext _dbContext;
        public SubastaService(TPI_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Subasta>> GetSubastasToCloseAsync(DateTime currentTime)
        {
            return await _dbContext.Subastas.Where(s => s.fechaFinalizado <= currentTime && s.estadoSubasta == Subasta.EstadoSubasta.Activa)
                                            .Include(p => p.listaProductos)
                                            .ToListAsync();
        }

        public async Task<List<Subasta>> GetSubastasToOpenAsync(DateTime currentTime)
        {
            return await _dbContext.Subastas.Where(s => s.fechaInicio <= currentTime && s.estadoSubasta == Subasta.EstadoSubasta.Proxima)
                                            .ToListAsync();
        }

        public async Task CloseSubastaAsync(Subasta subasta)
        {
           
                subasta.estadoSubasta = Subasta.EstadoSubasta.Finalizadas;

            if (subasta.listaProductos != null)
            {
                foreach (var producto in subasta.listaProductos)
                {

                    if (producto.estadoProducto == Producto.EstadoProducto.EnRevision ||
                        producto.estadoProducto == Producto.EstadoProducto.NoVendido)
                    {
                        continue;
                    }

                    var ofertas = await _dbContext.Ofertas
                            .Where(o => o.productoID == producto.productoID && o.estadoOferta == Oferta.EstadoOferta.Pendiente)
                            .OrderByDescending(o => o.montoOferta)
                            .ToListAsync();

                    if (ofertas.Any())
                    {
                        var ofertaGanadora = ofertas.First();
                        ofertaGanadora.estadoOferta = Oferta.EstadoOferta.Ganadora;

                        producto.estadoProducto = Producto.EstadoProducto.Vendido;

                        foreach (var oferta in ofertas.Skip(1))
                        {
                            oferta.estadoOferta = Oferta.EstadoOferta.NoGanadora;
                        }

                    }
                    else
                    {
                        producto.estadoProducto = Producto.EstadoProducto.NoVendido;
                    }
                }
            }
                await _dbContext.SaveChangesAsync();
            
        }

        public async Task OpenSubastaAsync(Subasta subasta)
        {

            subasta.estadoSubasta = Subasta.EstadoSubasta.Activa;
            _dbContext.Subastas.Update(subasta);
            await _dbContext.SaveChangesAsync();
        }

    }
}



