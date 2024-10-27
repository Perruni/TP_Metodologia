using Core.Data;
using Core.Entities;
using Core.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Core.Shared.DTOs.Subastas;
using Core.Shared.DTOs.Producto;
using Core.Shared.DTOs.Usuario;
using System.Net.Http.Headers;
using Core.Shared.DTOs.Oferta;

namespace Web_Subasta.Controllers
{
    [Route("/[controller]")]
    
    public class OfertaController : Controller
    {
        static HttpClient client = new HttpClient();


        static async Task InitializeHttpClientAsync()
        {
            client.BaseAddress = new Uri("UriStrings");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }


        [HttpGet("usuario/{userID}")]
        public async Task<IActionResult> GetUsuarioOf(int userID)
        {
            Usuario usuario = null;

            await InitializeHttpClientAsync();
            HttpResponseMessage response = await client.GetAsync($"api/Oferta/Usuario/{userID}");

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

        [HttpGet("oferta/ID/{offerID}")]
        public async Task<IActionResult> GetOfertante(int offerID)
        {
            Oferta oferta = null;

            await InitializeHttpClientAsync();
            HttpResponseMessage response = await client.GetAsync($"api/Oferta/ID/{offerID}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                oferta = JsonSerializer.Deserialize<Oferta>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            }

            if (oferta == null)
            {
                return NotFound();
            }
            return Ok(oferta);
        }


        [HttpGet("Resultados/{subastaID}")]
        public async Task<IActionResult> GetOfertasGanadoras(int subastaID)
        {
            Oferta oferta = null;

            await InitializeHttpClientAsync();
            HttpResponseMessage response = await client.GetAsync($"api/Oferta/Resultado/{subastaID}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                oferta = JsonSerializer.Deserialize<Oferta>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            }

            if (oferta == null)
            {
                return NotFound();
            }
            return Ok(oferta);
        }

        [HttpGet("oferta/{productoID}")]
        public async Task<IActionResult> GetOfertaProducto(int productoID)
        {
            Oferta oferta = null;

            await InitializeHttpClientAsync(); 

            HttpResponseMessage response = await client.GetAsync($"api/Oferta/{productoID}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                oferta = JsonSerializer.Deserialize<Oferta>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            }

            if (oferta == null)
            {
                return NotFound();
            }
            return Ok(oferta);
        }


        [HttpPost]
        public async Task<IActionResult> PostOferta([FromBody] OfertaDTO ofertaDto)
        {
            if (ofertaDto == null)
            {
                return BadRequest("Los datos de la oferta son inválidos");
            }

            await InitializeHttpClientAsync();


            var data = new
            {
                MontoOferta = ofertaDto.montoOferta
            };


            var jsonData = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");


            HttpResponseMessage response = await client.PostAsJsonAsync("api/Oferta", content);

            if (response.IsSuccessStatusCode)
            {

                return Ok("Datos enviados correctamente.");
            }
            else
            {

                return StatusCode((int)response.StatusCode, "Error al enviar los datos.");
            }
        }



    }
}
