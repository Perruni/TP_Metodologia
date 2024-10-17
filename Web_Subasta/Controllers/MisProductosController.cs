using Core.Data;
using Core.Shared;
using Core.Shared.DTOs.Producto;
using Core.Shared.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Master_API.Controllers
{
    public class MisProductosController : Controller
    {
        private readonly TPI_DbContext _context;

        public MisProductosController(TPI_DbContext context)
        {
            _context = context;
        }

        [HttpGet("/MisProductos/{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuarioProductos(int id)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.listaProductos)
                .FirstOrDefaultAsync(u => u.usuarioID == id);

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
                    nombreProducto = p.nombreProducto,
                    precioBase = p.precioBase,
                    metodoEntrega = p.metodoEntrega,
                    estadoProducto = p.estadoProducto,
                }).ToList(),

            };

            return usuarioDTO;
        }
    }
}
