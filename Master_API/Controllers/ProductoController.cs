using BlobImagesTest.Services;
using Core.Busisness.Interfaces;
using Core.Data;
using Core.Data.Interface;
using Core.Entities;
using Core.Shared;
using Core.Shared.DTOs.Producto;
using Core.Shared.DTOs.Subastas;
using Core.Shared.DTOs.Usuario;
using Core.Shared.Enum;
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
        private readonly IAzureBlobStorageService _azureBlobStorageService;

        public ProductoController(IProductoBusiness productoBusiness, IAzureBlobStorageService azureBlobStorageService)
        {
            _productoBusiness = productoBusiness;
            _azureBlobStorageService = azureBlobStorageService;
        }

        
        [HttpGet("{productID}")]
        public async Task<ActionResult<Producto>> GetProductID(int productID)
        {

            var product = await _productoBusiness.GetProducto(productID);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }        

        [HttpGet("Productos")]
        public async Task<ActionResult<Producto>> GetAll()
        {


            var product = await _productoBusiness.GetProductos();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }

        [HttpGet("Usuario/{userID}")]
        public async Task<ActionResult<Producto>> GetProductoUsuario(int userID)
        {


            var product = await _productoBusiness.GetProductoUsuario(userID);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }

        [HttpPost("{userId}/{subastaId}")]
        public async Task<ActionResult<Producto?>> PostProducto([FromForm] ProductoDTO request, int userId, int subastaId)
        {
            // Validación del modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string imagenUrl = null;
            if (request.imagenUrl != null)
            {
                imagenUrl = await _azureBlobStorageService.UploadAsync(request.imagenUrl, Container.contenedorimagenes);
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
                ImagenUrl = imagenUrl
            };

            // Agregar el nuevo producto al contexto
            await _productoBusiness.AddProducto(nuevoProducto);

            return CreatedAtAction(nameof(GetProductID), new { productID = nuevoProducto.productoID }, nuevoProducto);

        }

        [HttpPut("Cancelar/{userId}/{productoID}")]
        public async Task<ActionResult<Producto?>> PutProducto(int userId, int productoID)
        {

            var producto = await _productoBusiness.GetProducto(productoID);

            if (producto.usuarioID != userId)
            {
                return Forbid();

            }            

            if (producto.estadoProducto == Producto.EstadoProducto.EnRevision)
            {
                producto.estadoSolicitud = Producto.EstadoSolicitud.Cancelado;
                producto.estadoProducto = Producto.EstadoProducto.NoVendido;
            }

            await _productoBusiness.CancelarProducto(producto);

            return Ok(producto);

        }




    }
}
