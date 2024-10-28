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

        /*[HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUsuario(int userId, [FromBody] UsuarioDTO usuarioDto)
        {
            if (usuarioDto == null)
            {
                return BadRequest("Los datos del usuario son inválidos");
            }

            var usuario = new Usuario
            {
                usuarioID = userId,
                email = usuarioDto.email,
                contrasenia = usuarioDto.contrasenia
            };

            
           // await InitializeHttpClientAsync();

           
            var jsonData = JsonSerializer.Serialize(usuario);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            
            HttpResponseMessage response = await client.PutAsync($"api/Usuarios/{userId}", content);

            if (response.IsSuccessStatusCode)
            {
                
                var updatedUsuario = await response.Content.ReadFromJsonAsync<UsuarioDTO>();
                return Ok(updatedUsuario);
            }
            else
            {
                
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        }


        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUsuario(int userId)
        {
           
           // await InitializeHttpClientAsync();

            
            HttpResponseMessage response = await client.DeleteAsync($"api/Usuarios/{userId}");

            if (response.IsSuccessStatusCode)
            {
                
                return Ok("Usuario eliminado correctamente.");
            }
            else
            {
               
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        }*/

    }
}
