using Core.Data;
using Core.Entities;
using Core.Shared.DTOs.Oferta;
using Core.Shared.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Web_Subasta.Models.ViewModels;
using Web_Subasta.Services;

namespace Web_Subasta.Controllers
{
    [Route("[controller]")]

    public class UsuarioController : Controller
    {

        private readonly IServiceAPI _serviceAPI;        
        private readonly TPI_DbContext _context;

        public UsuarioController(TPI_DbContext context, IServiceAPI serviceAPI)
        {
            _context = context;

            _serviceAPI = serviceAPI;
        }
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View("~/Views/Acount/login.cshtml");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Retorna el modelo con errores si no es válido
            }

            // Aquí llamas al servicio para verificar las credenciales del usuario
            var usuario = await _serviceAPI.LoginUsuario(model.email, model.contrasenia);

            if (usuario != null)
            {
                // Si el usuario existe, lo rediriges a la página de subastas o cualquier otra página
                return RedirectToAction("Subasta", "Activas");
            }

            ModelState.AddModelError(string.Empty, "Credenciales inválidas.");
            return View("~/Views/Acount/login.cshtml"); // Si las credenciales son incorrectas, vuelve al formulario de login
        }


        [HttpGet("Usuario/{userID}")]
        public async Task<IActionResult> GetUsuario(int userID)
        {
            if (userID <= 0)
            {
                ModelState.AddModelError(string.Empty, "El ID de usuario no es válido.");
                return BadRequest(ModelState);
            }

            var usuario = await _serviceAPI.GetUsuario(userID);

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Error al obtener los datos del usuario.");
                return View("Login");
            }

            return View("Activas", usuario);
        }


        [HttpPost]
        public async Task<IActionResult> PostUsuario(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", model);
            }

            var data = new Usuario
            {
                email = model.Email,
                contrasenia = model.Contrasenia,
            };

            var respuesta = await _serviceAPI.AddUsuario(data);

            if (respuesta != null)
            {
                return RedirectToAction("DatosUsuario");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error al registrar el usuario.");
                return View("Register", model);
            }
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUsuario(int userId, [FromBody] UsuarioDTO usuarioDto)
        {
            if (usuarioDto == null || userId <= 0)
            {
                return BadRequest("Datos inválidos.");
            }

            var usuario = new Usuario
            {
                usuarioID = userId,
                email = usuarioDto.email,
                contrasenia = usuarioDto.contrasenia
            };

            var resultado = await _serviceAPI.UpdateUsuario(usuario, userId);

            if (resultado == null)
            {
                return NotFound("No se pudo actualizar el usuario.");
            }

            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUsuario(int userId)
        {
            if (userId != null)
            {
                return BadRequest("ID de usuario inválido.");
            }

            var usuario = await _serviceAPI.GetUsuario(userId);

            if (usuario == null)
            {
                return NotFound("El usuario no fue encontrado.");
            }

            var resultado = await _serviceAPI.Deleteusuario(userId);

            if (resultado != null)
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Error al eliminar el usuario.");
            }
        }
    }

}
