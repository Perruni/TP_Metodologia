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

namespace Web_Subasta.Controllers
{
    [Route("/producto/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        static HttpClient client = new HttpClient();

        
        static async Task InitializeHttpClientAsync()
        {
            client.BaseAddress = new Uri("UriStrings"); 
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        
        [HttpGet("{ProductoID}")]
        public async Task<IActionResult> GetProducto(int ProductoID)
        {
            Producto producto = null;

            await InitializeHttpClientAsync();
            HttpResponseMessage response = await client.GetAsync($"api/producto/{ProductoID}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                producto = JsonSerializer.Deserialize<Producto>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }
    }
}