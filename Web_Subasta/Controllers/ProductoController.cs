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
using static Core.Entities.Producto;

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
        public async Task<IActionResult> GetProductoID(int productoID)
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
        public async Task<IActionResult> PostProducto(ProductoViewModel productoVM, int userId, int subastaId)
        {
            if (productoVM == null)
            {
                return BadRequest("Los datos del producto son inválidos");
            }
            subastaId = 1;
            userId = 1;


            var data = new ProductoDTO{
                nombreProducto = productoVM.NombreProducto,
                precioBase = productoVM.PrecioBase,
                descripcion = productoVM.Descripcion,
                metodoEntrega = productoVM.MetodoEntrega,
                imagenUrl = productoVM.ImagenUrlArchivo,
               
            };

          
            var respuesta = await _service.AddProducto(data, userId, subastaId);

            if (respuesta != null)
            {
                return View("~/Views/Home/MisProductos.cshtml");
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


        [HttpGet("detallesproducto")]
        public async Task<IActionResult> GetDetallesProducto(int productoID)
        {
          
                var producto = await _service.GetProducto(productoID);

                var subasta = await _service.GetSubasta((int)producto.subastaID);

            var cantidadOfertas = await _service.GetCantidadOfertas(productoID);



                if (producto != null)
                {
                var viewModel = new ProductoViewModel
                {
                    Producto = producto,
                    Subasta = subasta,
                    fechaInicio = subasta.fechaInicio,
                    fechaFinalizado = subasta.fechaFinalizado,
                    NombreProducto = producto.nombreProducto,
                    Descripcion = producto.descripcion,
                    PrecioBase = producto.precioBase,
                    CantidadOfertas = cantidadOfertas,
                    Titulo = subasta.titulo,
                    EstadoProducto = (EstadoProducto)subasta.estadoSubasta

                };
                    return View("~/Views/Home/productos.cshtml", viewModel);
                }
                return NotFound();
            
         
        }
        [HttpGet("productosubasta")]
        public async Task<IActionResult> ProductosEnSubasta(int subastaID)
        {

            var subasta = await _service.GetSubastaProductos(subastaID);
            Console.WriteLine(subasta); // Imprimir en la consola para depuración
            if (subasta == null)
            {
                return NotFound();
            }

            if (subasta.listaProductos == null)
            {
                subasta.listaProductos = new List<Producto>(); 
            }

            var viewModel = new ProductoViewModel
            {
                Subasta = subasta,
                Titulo = subasta.titulo,
                fechaInicio = subasta.fechaInicio,
                fechaFinalizado = subasta.fechaFinalizado,
                productoUsuario = subasta.listaProductos
            };

            return View("~/Views/Home/productosSubasta.cshtml", viewModel);
        }

    }
}