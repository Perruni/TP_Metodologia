using Microsoft.AspNetCore.Mvc;
using Web_Subasta.Models.ViewModels;
using Core.Data; // Asegúrate de que esta línea esté correcta para tu espacio de nombres
using Core.Entities; // Importa tu entidad Usuario
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

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
                };

                // Guarda el nuevo usuario en la base de datos
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                // Ahora el usuarioID se ha asignado automáticamente
                var nuevoUsuarioID = usuario.usuarioID; // Obtén el usuarioID asignado

                
                    // Redirigir a la acción para completar los datos del usuario
                    return RedirectToAction("DatosUsuario", "Home", new { userId = nuevoUsuarioID});
                  
            }

            // Si llegamos aquí, algo falló; vuelve a mostrar el formulario
            return View("activas", "home");
        }

    }
}
