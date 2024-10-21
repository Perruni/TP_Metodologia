using Core.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web_Subasta.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

public class LoginController : Controller
{
    private readonly TPI_DbContext _context;

    public LoginController(TPI_DbContext context)
    {
        _context = context;
    }

    // Procesar el login
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Recuperar el usuario por correo electrónico
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.email == model.email && u.contrasenia == model.contrasenia);

        if (usuario != null)
        {
            // Si las credenciales son correctas, redirigir a la página principal o donde desees
            return RedirectToAction("Activas", "Home");
        }

        // Si las credenciales son incorrectas
        ModelState.AddModelError(string.Empty, "Correo o contraseña incorrectos");
        return View(model);
    }
}
