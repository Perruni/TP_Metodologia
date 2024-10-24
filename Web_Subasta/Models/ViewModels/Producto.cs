using Microsoft.AspNetCore.Mvc;

namespace Web_Subasta.Models.ViewModels
{
    public class Producto : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
