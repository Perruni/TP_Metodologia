using Core.Data;
using Core.Entities;
using Core.Shared;
using Core.Shared.DTOs.SubastasDTO;
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
        public async Task<ActionResult<ProductoDTO>> PostProducto(ProductoDTO productoDTO, [FromBody] SubastaIdDTO subastaIdDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nuevoProducto = new Producto
            {
                nombreProducto = productoDTO.NombreProducto,
                precioBase = productoDTO.PrecioBase,
                metodoEntrega = productoDTO.MetodoEntrega,
                fechaSolicitud = productoDTO.FechaSolicitud,
                estadoProducto = productoDTO.EstadoProducto,
                // Asociar el producto a la subasta
                subastaID = subastaIdDTO.subastaID // Suponiendo que hay una propiedad SubastaID en la entidad Producto
            };

            // Agregar el nuevo producto al contexto
            await _context.Productos.AddAsync(nuevoProducto);
            await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos

            // Convertir a DTO para la respuesta
            var productoResponseDTO = new ProductoDTO
            {
                ProductoID = nuevoProducto.productoID, // Asumiendo que el ID se genera al guardar
                NombreProducto = nuevoProducto.nombreProducto,
                PrecioBase = nuevoProducto.precioBase,
                MetodoEntrega = nuevoProducto.metodoEntrega,
                FechaSolicitud = nuevoProducto.fechaSolicitud,
                EstadoProducto = nuevoProducto.estadoProducto,
            };

            return CreatedAtAction(nameof(GetProductID), new { ProductoID = productoResponseDTO.ProductoID }, productoResponseDTO);
        }

    }
}
