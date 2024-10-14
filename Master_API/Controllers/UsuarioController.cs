using Microsoft.AspNetCore.Mvc;

namespace Master_API.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
