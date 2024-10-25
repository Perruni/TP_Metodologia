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

namespace Master_API.Controllers
{
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


        [HttpGet("{userID}")]
        public async Task<IActionResult> GetProducto(int userID)
        {
            Usuario usuario = null;

            await InitializeHttpClientAsync();
            HttpResponseMessage response = await client.GetAsync($"api/Usuario/{userID}");

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


    }
}
