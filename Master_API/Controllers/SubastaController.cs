using Core.Data;
using Core.Shared.DTOs.Producto;
using Core.Shared.DTOs.Subastas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Master_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubastaController : ControllerBase
    {

        private readonly TPI_DbContext _context;

        public SubastaController(TPI_DbContext context)
        {
            _context = context;
        }

        [HttpGet("/SubastaActiva/{id}")]
        public async Task<ActionResult<SubastaProductosDTO>> GetSubastaActivaProductos(int id)
        {
            var subasta = await _context.Subastas
                .Include(s => s.listaProductos)
                .FirstOrDefaultAsync(s => s.subastaID == id);

            if (subasta == null)
            {
                return NotFound();
            }

            var subastaProductosDTO = new SubastaProductosDTO
            {
                subastaID = subasta.subastaID,
                listaProductos = subasta.listaProductos.Select(p => new ProductoDatosDTO
                {
                    nombreProducto = p.nombreProducto,
                    precioBase = p.precioBase,
                    metodoEntrega = p.metodoEntrega,
                    fechaSolicitud = p.fechaSolicitud,
                    estadoProducto = p.estadoProducto
                }).ToList(),

            };

            return subastaProductosDTO;
        }
    }
}
