using Core.Data;
using Core.Entities;
using Core.Shared.DTOs.Producto;
using Core.Shared.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Master_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaController : Controller
    {
        private readonly TPI_DbContext _context;

        public OfertaController(TPI_DbContext context)
        {
            _context = context;
        }

        /*
        [HttpGet("/MisOfertas/{id}")]
        public async Task<ActionResult<Oferta>> GetUsuarioOfertas(int id)
        {
            var oferta = await _context.Ofertas.Where(o=>o.usuarioID == id);
                

            if (usuario == null)
            {
                return NotFound();
            }

            // Mapeo manual del Usuario a UsuarioDTO
            var usuarioDTO = new UsuarioDTO
            {
                usuarioID = usuario.usuarioID,
                listaProductos = usuario.listaProductos.Select(p => new ProductoDTO
                {
                    ProductoID = p.productoID,
                    NombreProducto = p.nombreProducto,
                    PrecioBase = p.precioBase,
                    MetodoEntrega = p.metodoEntrega,
                    FechaSolicitud = p.fechaSolicitud,
                    EstadoProducto = p.estadoProducto
                }).ToList(),

            };

            return usuarioDTO;
        }*/
    }
}
