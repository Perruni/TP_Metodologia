using Core.Busisness.Interfaces;
using Core.Data;
using Core.Data.Interface;
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
        private readonly IProjectRepository _repository;

        public ProductoController(IProductoBusiness productoBusiness,IProjectRepository repository)
        {
            _productoBusiness = productoBusiness;
            _repository = repository;
        }

        
        [HttpGet("{ProductoID}")]
        public async Task<ActionResult<Producto>> GetProductID(int ProductoID)
        {

            var product = await _productoBusiness.GetProducto(ProductoID);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }

        [HttpGet("UserOwner/{productoID}")]
        public async Task<ActionResult<ProductoDTO>> GetUserOwner(int productoID)
        {


            var product = await _repository.DuenoProducto(productoID);

            if (product == null)
            {
                return NotFound();
            }
            var productoDto = new ProductoDTO
            {
                nombreProducto = product.nombreProducto,
                precioBase = product.precioBase,
                metodoEntrega = product.metodoEntrega,
                fechaSolicitud = product.fechaSolicitud,
                descripcion = product.descripcion,
                estadoProducto = product.estadoProducto
                Usuario = new UsuarioDTO
                {
                    DNI = product.Usuario.DatosUsuario.DNI
                    nombre = product.Usuario.DatosUsuario.nombre


                                                            

                }
            };

            return Ok(product);

        }

        [HttpGet("Productos")]
        public async Task<ActionResult<Producto>> GetAll()
        {


            var product = await _productoBusiness.GetAll();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }    

        
        [HttpPost("{userId}/{subastaId}")]
        public async Task<ActionResult<Producto?>> PostProducto(CrearProductoDTO request, int userId, int subastaId)
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
                nombreProducto = request.nombreProducto,
                precioBase = request.precioBase,
                metodoEntrega = request.metodoEntrega,
                fechaSolicitud = DateTime.Now,
                descripcion = request.descripcion,
                estadoProducto = Producto.EstadoProducto.EnRevision,
                estadoSolicitud = Producto.EstadoSolicitud.Pendiente,
            };

            // Agregar el nuevo producto al contexto
            await _productoBusiness.AddProducto(nuevoProducto);            

            return Ok(nuevoProducto);

        }

    }
}
