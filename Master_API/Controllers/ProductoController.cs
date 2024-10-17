using Core.Busisness.Interfaces;
using Core.Data;
using Core.Entities;
using Core.Shared;
using Core.Shared.DTOs.Producto;
using Core.Shared.DTOs.Subastas;
using Core.Shared.DTOs.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Master_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoBusiness _productoBusiness;
        private readonly TPI_DbContext _context;

        public ProductoController(TPI_DbContext context, IProductoBusiness productoBusiness)
        {
            _context = context;
            _productoBusiness = productoBusiness;
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
        public async Task<ActionResult<ProductoDTO>> GetAll()
        {


            var product = _productoBusiness.GetAll();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }    

        
        [HttpPost("{userId}/{subastaId}")]
        public async Task<ActionResult<Producto?>> PostProducto(ProductoDTO request, int userId, int subastaId)
        {
            // Validación del modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }           
            

            // Crear una nueva instancia de Producto
            var nuevoProducto = new Producto
            {
                usuarioID = userId,
                subastaID = subastaId,
                nombreProducto = request.NombreProducto,
                precioBase = request.PrecioBase,
                metodoEntrega = request.MetodoEntrega,
                fechaSolicitud = request.FechaSolicitud,
                descripcion = request.Descripcion,
                estadoProducto = request.estadoProducto,                
            };

            // Agregar el nuevo producto al contexto
            await _context.Productos.AddAsync(nuevoProducto);
            await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos            

            return Ok(nuevoProducto);

        }

    }
}
