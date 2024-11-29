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
using System.Collections.Generic;

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
        [HttpGet]
        public async Task<IActionResult> VenderProducto()
        {
            var subastasProximas = await _service.GetSubastasProximas();

            var viewModel = new ProductoViewModel
            {
                subastaLista = subastasProximas
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> PostProducto(ProductoViewModel productoVM, int subastaId)
        {

            var userClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userClaim) || !int.TryParse(userClaim, out int userID) || userID == 0)
            {
                return RedirectToAction("login", "Usuario");
            }

            if (productoVM == null)
            {
                return BadRequest("Los datos del producto son inválidos");
            }
            string imagenUrl = null;

            if (productoVM.ImagenUrlArchivo != null && productoVM.ImagenUrlArchivo.Length > 0)
            {
                imagenUrl = await _azureBlobStorageService.UploadAsync(productoVM.ImagenUrlArchivo, Container.contenedorimagenes);
            }

            var nuevoProducto = new Producto
            {
                usuarioID = userID,
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

            try
            {
                var resultado = await _productoBusiness.AddProducto(nuevoProducto);
                if (resultado != null)
                {
                    return RedirectToAction("MisProductos","Producto");
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                // Log or inspect the error
                Console.WriteLine($"Error: {ex.Message}");
                return BadRequest("Hubo un error al guardar el producto.");
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

            var ofertamasalta = await _service.GetOfertaGanadora(productoID);

            

            bool esSubastaFinalizada = subasta.estadoSubasta == Subasta.EstadoSubasta.Finalizadas || subasta.fechaFinalizado <= DateTime.Now;

            bool esVendedor = false;
            bool esGanador = false;
            string nombreGanador = null;

            if (esSubastaFinalizada)
            {
                var ganador = await _service.GetDatosUsuario(ofertamasalta.usuarioID.Value);
                nombreGanador = ganador.nombre + " " + ganador.apellido;

                if (User.Identity.IsAuthenticated)
                {
                    int usuarioID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                    esVendedor = usuarioID == producto.usuarioID;
                    esGanador = usuarioID == ofertamasalta?.usuarioID; 
                }
            }


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
                    EstadoProducto = (EstadoProducto)producto.estadoProducto,
                    EsSubastaFinalizada = esSubastaFinalizada,
                    EsVendedor = esVendedor,
                    EsGanador = esGanador,
                    NombreGanador = nombreGanador


                };
                    return View("~/Views/Home/productos.cshtml", viewModel);
                }
                return NotFound(); 
        }
        [HttpGet("productosubasta")]
        public async Task<IActionResult> ProductosEnSubasta(int subastaID)
        {

            var subasta = await _service.GetSubastaProductos(subastaID);

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
                productoUsuario = subasta.listaProductos,
                EstadoSubasta = subasta.estadoSubasta
               
            };

            return View("~/Views/Home/productosSubasta.cshtml", viewModel);
        }
        [HttpGet("MisProductos")]
        public async Task<IActionResult> MisProductos()
        {
            ProductoViewModel viewModel = new ProductoViewModel();

            try
            {
                var userClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userClaim) || !int.TryParse(userClaim, out int userID) || userID == 0)
                {
                    return RedirectToAction("login", "Usuario");
                }
                // Obtener productos del usuario mediante la capa de negocio
                var productos = await _productoBusiness.GetProductoUsuario(userID);

                if (productos != null && productos.Any())
                {
                    viewModel.productoUsuario = productos;
                }
                else
                {
                    viewModel.productoUsuario = new List<Producto>();
                    ViewBag.ErrorMessage = "No se encontraron productos para este usuario.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al intentar obtener los productos.";
                Console.WriteLine(ex.Message);
            }

            return View("~/Views/Home/MisProductos.cshtml",viewModel);
        }

       

        [HttpGet("Certificado")]
        public async Task<IActionResult> Certificado(int productoID)
        {

            var producto = await _service.GetProducto(productoID);
            if (producto == null)
            {
                return NotFound("Producto no encontrado.");
            }

            var vendedor = await _service.GetDatosUsuario(producto.usuarioID.Value);
            if (vendedor == null)
            {
                return NotFound("Vendedor no encontrado.");
            }

            var oferta = await _service.GetOfertaGanadora(productoID);
            if (oferta == null)
            {
                return NotFound("Oferta ganadora no encontrada.");
            }

            var ganador = await _service.GetDatosUsuario(oferta.usuarioID.Value);
            if (ganador == null)
            {
                return NotFound("Ganador no encontrado.");
            }

            var subasta = await _service.GetSubasta(producto.subastaID.Value);
            if (subasta == null)
            {
                return NotFound("Subasta no encontrada.");
            }



            if (producto != null)
            {
                var viewModel = new CertificadoViewModel
                {
                    ProductoID = producto.productoID,
                    NombreProducto = producto.nombreProducto,
                    PrecioBase = oferta.montoOferta,
                    MetodoEntrega = producto.metodoEntrega,
                    FechaSolicitud = producto.fechaSolicitud,

                    // Datos de la subasta
                    TituloSubasta = subasta.titulo,
                    FechaFinalizadoSubasta = subasta.fechaFinalizado,
                    MetodoPago = subasta.metodosdePago.ToString(),

                    // Datos del ganador
                    NombreGanador = ganador.nombre + " " + ganador.apellido,
                    ContactoGanador = ganador.telefono,
                    DomicilioGanador = ganador.direccion,
                    DniGanador = ganador.DNI.ToString(),

                    // Datos del vendedor
                    NombreVendedor = vendedor.nombre + " " + vendedor.apellido,
                    ContactoVendedor = vendedor.telefono,
                    DomicilioVendedor = vendedor.direccion,
                    DniVendedor = vendedor.DNI.ToString(),

                };
                return View("~/Views/Home/Certificado.cshtml", viewModel);
            }
            return NotFound();

        }
        [HttpGet("GanadoresSubastas/{subastaID}")]
        public async Task<IActionResult> GanadoresSubastas(int subastaID)
        {
            var subasta = await _service.GetSubasta(subastaID);
            if (subasta == null)
            {
                return NotFound("Subasta no encontrada.");
            }

            var subastaConProductos = await _service.GetSubastaProductos(subastaID);
            if (subastaConProductos?.listaProductos == null || !subastaConProductos.listaProductos.Any())
            {
                TempData["ErrorMessage"] = "No hay ganadores en esta subasta.";
                return RedirectToAction("Finalizadas", "Subasta");
            }

            var ganadoresViewModel = new List<GanadorSubastaViewModel>();

            foreach (var producto in subastaConProductos.listaProductos)
            {
                var ofertaGanadora = await _service.GetOfertaGanadora(producto.productoID);

                if (ofertaGanadora != null)
                {
                    var ganador = await _service.GetDatosUsuario(ofertaGanadora.usuarioID.Value);
                    if (ganador != null)
                    {
                        var vendedor = await _service.GetDatosUsuario(producto.usuarioID.Value);

                        var ganadorViewModel = new GanadorSubastaViewModel
                        {
                            ProductoID = producto.productoID,
                            NombreProducto = producto.nombreProducto,
                            PrecioBase = (decimal)ofertaGanadora.montoOferta,
                            NombreGanador = ganador.nombre + " " + ganador.apellido,
                            NombreVendedor = vendedor?.nombre + " " + vendedor?.apellido,
                            TituloSubasta = subasta.titulo,
                            FechaFinalizadoSubasta = subasta.fechaFinalizado
                        };

                        ganadoresViewModel.Add(ganadorViewModel);
                    }
                }
            }

            return View("~/Views/Home/Ganadores.cshtml", ganadoresViewModel);
        }



    }
}