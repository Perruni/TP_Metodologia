using Microsoft.AspNetCore.Mvc;

namespace Web_Subasta.Controllers
{
    public class Login : Controller
    {
        public IActionResult login()
        {
            return View();
        }
    }
}
