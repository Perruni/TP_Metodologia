using Microsoft.AspNetCore.Mvc;
using Web_Subasta.Models.ViewModels;
using Core.Data; // Asegúrate de que esta línea esté correcta para tu espacio de nombres
using Core.Entities; // Importa tu entidad Usuario
using System.Threading.Tasks;

namespace Web_Subasta.Controllers
{
    public class RegisterController : Controller
    {
        private readonly TPI_DbContext _context;

        public RegisterController(TPI_DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reg(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Crea una nueva entidad Usuario
                var usuario = new Usuario
                {
                    email = model.Email,
                    contrasenia = model.Contrasenia // Almacena la contraseña sin hashing (no recomendado)
                    // Otros campos a agregar si es necesario
                };

                // Guarda el nuevo usuario en la base de datos
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                // Redirigir a una acción después del registro, como un mensaje de éxito o iniciar sesión
                return RedirectToAction("Activas", "Home"); // Redirige a la página de inicio de sesión
            }

            // Si llegamos aquí, algo falló; vuelve a mostrar el formulario
            return View("Index", model);
        }
    }
}
