using Core.Data;
using Core.Entities;
using Core.Shared.DTOs.Oferta;
using Core.Shared.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Web_Subasta.Controllers
{
    [Route("/[controller]")]

    public class UsuarioController : Controller
    {

        static HttpClient client = new HttpClient();


        static async Task InitializeHttpClientAsync()
        {
            client.BaseAddress = new Uri("UriStrings");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpGet("Usuario/{UsuarioID}")]
        public async Task<IActionResult> GetUsuario(int UsuarioID)
        {
            Usuario usuario = null;

            await InitializeHttpClientAsync();
            HttpResponseMessage response = await client.GetAsync($"api/Usuario/{UsuarioID}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                usuario = JsonSerializer.Deserialize<Usuario>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            }

            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }


        [HttpPost]
        public async Task<IActionResult> PostUsuario([FromBody] UsuarioDTO usuarioDto)
        {
            if (usuarioDto == null)
            {
                return BadRequest("Los datos de la oferta son inválidos");
            }

            await InitializeHttpClientAsync();


            var data = new
            {
                Email = usuarioDto.email,
                Contrasenia = usuarioDto.contrasenia,
            };


            var jsonData = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");


            HttpResponseMessage response = await client.PostAsJsonAsync("api/Usuario", content);

            if (response.IsSuccessStatusCode)
            {

                return Ok("Datos enviados correctamente.");
            }
            else
            {

                return StatusCode((int)response.StatusCode, "Error al enviar los datos.");
            }
        }


        [HttpPut("{userId}")]
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

            
            await InitializeHttpClientAsync();

           
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
           
            await InitializeHttpClientAsync();

            
            HttpResponseMessage response = await client.DeleteAsync($"api/Usuarios/{userId}");

            if (response.IsSuccessStatusCode)
            {
                
                return Ok("Usuario eliminado correctamente.");
            }
            else
            {
               
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        }

    }
}
