using Microsoft.AspNetCore.Mvc;

namespace Web_Subasta.Controllers
{
    public class Productos : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
