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


        [HttpGet("Usuario/{userID}")]
        public async Task<IActionResult> GetUsuario(int userID)
        {
           
            if (userID != null)
            {
                ModelState.AddModelError(string.Empty, "El ID de usuario No existe.");
                return BadRequest(ModelState);
            }
            
            var usuario = await _serviceAPI.GetUsuario(userID);

           
            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Error al enviar los datos.");
                return View("login");
            }
    
            return View("Activas"); 
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
                return View("DatosUsuario");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error al enviar los datos.");
                return View("Register", model);
            }
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUsuario(int userId, [FromBody] UsuarioDTO usuarioDto)
        {
            
            if (usuarioDto == null)
            {
                return BadRequest("Los datos del usuario son inválidos.");
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
                return NotFound("El usuario no se pudo encontrar o actualizar.");
            }

            
            return NoContent();
        }


        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUsuario(int userId)
        {
            
            var usuario = await _serviceAPI.GetUsuario(userId);

           
            if (usuario == null)
            {
                return NotFound("El usuario no fue encontrado.");
            }

            
            var resultado = await _serviceAPI.Deleteusuario(userId);

            
            if (resultado == null) 
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
