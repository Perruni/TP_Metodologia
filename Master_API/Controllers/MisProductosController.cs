using Microsoft.AspNetCore.Mvc;

namespace Master_API.Controllers
{
    public class MisProductosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
