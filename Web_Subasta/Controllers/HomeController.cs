using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_Subasta.Models;

namespace Web_Subasta.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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





        public IActionResult productos()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
