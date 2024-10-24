using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using Web_Subasta.Models;
using Core.Data;
using Microsoft.EntityFrameworkCore;
using Core.Shared.DTOs.Producto;
using Core.Shared.DTOs.Usuario;
using Core.Shared.DTOs.Subastas;

namespace Web_Subasta.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HomeController> _logger;
        private readonly TPI_DbContext _context;

        public HomeController(TPI_DbContext context, IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View("Index");
        }

        
        public IActionResult Activas()
        {
            return View();
        }

        public IActionResult Proximas()
        {
            return View();
        }

        public IActionResult Finalizadas()
        {
            return View();
        }
        public IActionResult ProductoSolitario()
        {
            return View();
        }
        public IActionResult SubastasActivas()
        {
            return View();
        }

        public IActionResult Vender()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult VenderProducto()
        {
            return View();
        }

        public IActionResult productos()
        {
            return View();
        }

        public IActionResult DatosUsuario()
        {
            return View();
        }

        public IActionResult login()
        {
            return View();
        }

        public IActionResult register()
        {
            return View();
        }


        public IActionResult MisProductos()
        {
            return View();
        }

        public IActionResult MisOfertas()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        

        [HttpGet]
        public IActionResult CargarProducto()
        {
            ViewBag.UsuarioID = 1;
            // Devuelve la vista "CargarProducto"
            return View("CargarProducto");
        }



        [HttpPost]
        public async Task<IActionResult> CargarProducto(CrearProductoDTO crearProductoDTO, int subastaID, int usuarioID)
        {
            if (!ModelState.IsValid)
            {
                return View(crearProductoDTO); // Devuelve la vista si hay errores
            }

            var client = _httpClientFactory.CreateClient();

            // Crear el objeto SubastaIdDTO
            var subastaIdDTO = new SubastaIdDTO
            {
                subastaID = subastaID
            };

            // Crear un objeto anónimo para enviar ambos DTO
            var requestData = new
            {
                crearProductoDTO,
                subastaIdDTO
            };

            // Llamar a la API
            var response = await client.PostAsJsonAsync("https://localhost:7073/api/Producto/CargarProducto", requestData);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index"); // Redirige a la vista de productos si la creación fue exitosa
            }

            // Manejo de errores si la respuesta no fue exitosa
            ModelState.AddModelError(string.Empty, "Error al cargar el producto.");
            return View(crearProductoDTO); // Devuelve el mismo modelo si hubo un error
        }
    }
}
