using Core.Data;
using Core.Entities;
using Core.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Core.Shared.DTOs.Subastas;
using Core.Shared.DTOs.Producto;
using Core.Shared.DTOs.Usuario;
using System.Net.Http.Headers;
using Web_Subasta.Services;
using Web_Subasta.Models.ViewModels;
using Core.Shared.DTOs.Oferta;

namespace Web_Subasta.Controllers
{
    [Route("/[controller]")]    
    public class ProductoController : Controller
    {

        private readonly TPI_DbContext _context;
        private readonly IServiceAPI _service;

        public ProductoController(TPI_DbContext context, IServiceAPI serviceAPI)
        {
            _context = context;
            _service = serviceAPI;

        }

        [HttpGet("{productoID}")]
        public async Task<IActionResult> GetProducto(int productoID)
        {
            try
            {
                var producto = await _service.GetProducto(productoID);

                if (producto == null)
                {
                    return NotFound(new { message = "Producto no encontrado" });
                }

                return Ok(producto); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error en el servidor", error = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> PostProducto([FromBody] ProductoDTO productoDto, int userId, int subastaId)
        {
            if (productoDto == null)
            {
                return BadRequest("Los datos del producto son inválidos");
            }


            var data = new ProductoDTO
            {
                nombreProducto = productoDto.nombreProducto,
                precioBase = productoDto.precioBase,
                descripcion = productoDto.descripcion,
                metodoEntrega =productoDto.metodoEntrega,
                imagenUrl = productoDto.imagenUrl,
               
            };

          
            var respuesta = await _service.AddProducto(data, userId, subastaId);

            if (respuesta != null)
            {
                return View("~/Views/Home/Activas.cshtml");
            }
            return NotFound();
        }


        [HttpPut("{userId}/{productoID}")]
        public async Task<IActionResult> UpdateProducto(int userId, int productoID)
        {
           
            
            var resultado = await _service.CancelarProducto(userId, productoID);

            if (resultado == null)
            {
                return NotFound("El producto no se pudo encontrar o actualizar.");
            }

            return View("~/Views/Home/MisProductos.cshtml");
        }


        [HttpGet("Usuario/{userID}")]
        public async Task<IActionResult> GetProductoUsuario(int userID)
        {
            List<Producto>? producto = null;

            producto = await _service.GetProductoUsuario(userID);


            if (producto != null)
            {
                var viewModel = new ProductoViewModel
                {
                    productoUsuario = producto
                };
                return View("~/Views/Home/MisProductos.cshtml", viewModel);
            }
            return NotFound();
        }
    }

}