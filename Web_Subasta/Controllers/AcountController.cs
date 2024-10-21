using Microsoft.AspNetCore.Mvc;

namespace Web_Subasta.Controllers
{
    public class AcountController : Controller
    {
        public IActionResult login()
        {
            return View();
        }

        public IActionResult register()
        {
            return View();
        }
    }
}
