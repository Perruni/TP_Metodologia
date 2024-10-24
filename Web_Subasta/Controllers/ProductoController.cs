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


        [HttpPost]
        public async Task<IActionResult> PostProducto(int userId, int subastaId)
        {
            
            await InitializeHttpClientAsync();

            
            var data = new
            {
                UserId = userId,
                SubastaID = subastaId
            };

            
            var jsonData = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            
            HttpResponseMessage response = await client.PostAsync("UriStrings api/Producto", content); 

            if (response.IsSuccessStatusCode)
            {
               
                return Ok("Datos enviados correctamente.");
            }
            else
            {
                
                return StatusCode((int)response.StatusCode, "Error al enviar los datos.");
            }
        }


        [HttpPut("{userId}/{productoId}")]
        public async Task<IActionResult> UpdateProducto(int userId, int productoId, [FromBody] ProductoDatosDTO productDto)
        {
            
            if (productDto == null)
            {
                return BadRequest("Los datos del producto son inválidos");
            }

            
            var producto = new Producto
            {
                ProductoID = productoId, 
                nombreProducto = productDto.nombreProducto,
                precioBase = productDto.precioBase,
                metodoEntrega = productDto.metodoEntrega,
                fechaSolicitud = productDto.fechaSolicitud,
                descripcion = productDto.descripcion,
                estadoProducto = productDto.estadoProducto
                
            };

            
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/productos/Cancelar/{userId}/{productoId}", producto);

            if (response.IsSuccessStatusCode)
            {
                var updatedProduct = await response.Content.ReadFromJsonAsync<ProductoDatosDTO>();
                return Ok(updatedProduct);
            }
            else
            {
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        }
    }
}