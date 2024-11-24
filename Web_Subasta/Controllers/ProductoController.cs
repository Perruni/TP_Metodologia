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
using BlobImagesTest.Services;
using Core.Busisness.Interfaces;
using Core.Shared.Enum;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Web_Subasta.Controllers
{
    [Route("/[controller]")]    
    public class ProductoController : Controller
    {

        private readonly TPI_DbContext _context;
        private readonly IServiceAPI _service;
        private readonly IProductoBusiness _productoBusiness;
        private readonly IAzureBlobStorageService _azureBlobStorageService;      


        public ProductoController(TPI_DbContext context, IServiceAPI serviceAPI, IProductoBusiness productoBusiness, IAzureBlobStorageService azureBlobStorageService)
        {
            _context = context;
            _service = serviceAPI;
            _productoBusiness = productoBusiness;
            _azureBlobStorageService = azureBlobStorageService;


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

            userId = 1;

            string imagenUrl = null;

            if (productoVM.ImagenUrlArchivo != null && productoVM.ImagenUrlArchivo.Length > 0)
            {
                imagenUrl = await _azureBlobStorageService.UploadAsync(productoVM.ImagenUrlArchivo, Container.contenedorimagenes);
            }

            var nuevoProducto = new Producto
            {
                usuarioID = userId,
                subastaID = subastaId,
                nombreProducto = productoVM.NombreProducto,
                precioBase = productoVM.PrecioBase,
                metodoEntrega = productoVM.MetodoEntrega,
                fechaSolicitud = DateTime.Now,
                descripcion = productoVM.Descripcion,
                estadoProducto = Producto.EstadoProducto.EnRevision,
                estadoSolicitud = Producto.EstadoSolicitud.Pendiente,
                ImagenUrl = imagenUrl // Aquí asignamos la URL de la imagen subida (si existe)
            };

            var resultado = await _productoBusiness.AddProducto(nuevoProducto);

            if (resultado != null)
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
                    ProductoID = productoID,
                    Producto = producto,
                    Subasta = subasta,
                    fechaInicio = subasta.fechaInicio,
                    fechaFinalizado = subasta.fechaFinalizado,
                    NombreProducto = producto.nombreProducto,
                    Descripcion = producto.descripcion,
                    PrecioBase = producto.precioBase,
                    CantidadOfertas = cantidadOfertas,
                    Titulo = subasta.titulo,
                    EstadoProducto = (EstadoProducto)producto.estadoProducto

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