using Core.Data;
using Core.Entities;
using Core.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Master_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly TPI_DbContext _context;

        public ProductoController(TPI_DbContext context)
        {
            _context = context;
        }

        
        [HttpGet("{ProductoID}")]
        public async Task<ActionResult<Producto>> GetProductID(int ProductoID)        {


            var product = await _context.Productos.FindAsync(ProductoID);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }

        [HttpGet("Productos")]
        public async Task<ActionResult<ProductoDTO>> GetAllProduct()
        {


            var product = await _context.Productos.FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }


        [HttpGet("/MisOfertas/{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuarioOfertas(int id)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.listaOfertas)
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
                    ProductoID = p.productoID,
                    NombreProducto = p.nombreProducto,
                    PrecioBase = p.precioBase,
                    MetodoEntrega = p.metodoEntrega,
                    FechaSolicitud = p.fechaSolicitud,
                    EstadoProducto = p.estadoProducto
                }).ToList(),

            };

            return usuarioDTO;
        }

        [HttpPost("/CargarProducto/")]
        public async Task<ActionResult<UsuarioDTO>> PostProducto()
        {

        }

    }
}
