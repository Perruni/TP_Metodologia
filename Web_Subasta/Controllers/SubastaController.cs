using Core.Data;
using Core.Entities;
using Core.Shared;
using Core.Shared.DTOs.Producto;
using Core.Shared.DTOs.Subastas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Master_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubastaController : ControllerBase
    {

        static HttpClient client = new HttpClient();


        static async Task InitializeHttpClientAsync()
        {
            client.BaseAddress = new Uri("UriStrings");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpGet("Subasta/{subastaID}")]
        public async Task<IActionResult> GetSubasta(int SubastaID)
        {
            Subasta subasta = null;

            await InitializeHttpClientAsync();
            HttpResponseMessage response = await client.GetAsync($"api/Subasta/{SubastaID}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                subasta = JsonSerializer.Deserialize<Subasta>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            }

            if (subasta == null)
            {
                return NotFound();
            }
            return Ok(subasta);
        }


        [HttpGet("Subasta/Productos/{subastaID}")]
        public async Task<IActionResult> GetProductoSubasta(int subastaID)
        {
            SubastaProductosDTO subastaProductosDTO = null;

            await InitializeHttpClientAsync();
            HttpResponseMessage response = await client.GetAsync($"api/Subasta/Productos/{subastaID}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                subastaProductosDTO = JsonSerializer.Deserialize<SubastaProductosDTO>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            if (subastaProductosDTO == null || subastaProductosDTO.listaProductos == null)
            {
                return NotFound("La subasta o la lista de productos no se encontraron.");
            }

            return Ok(subastaProductosDTO);

        }

        [HttpGet("Activa")]
        public async Task<IActionResult> Activa()
        {
            var response = await client.GetAsync("/Activa");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var subasta = JsonSerializer.Deserialize<Subasta>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return Ok(subasta);
            }
            return NotFound();
        }

        [HttpGet("Proximas")]
        public async Task<IActionResult> Proximas()
        {
            var response = await client.GetAsync("/Proximas");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var subasta = JsonSerializer.Deserialize<Subasta>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return Ok(subasta);
            }
            return NotFound();
        }

        [HttpGet("Finalizadas")]
        public async Task<IActionResult> Finalizadas()
        {
            var response = await client.GetAsync("/Finalizadas");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var subasta = JsonSerializer.Deserialize<Subasta>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return Ok(subasta);
            }
            return NotFound();
        }




        //Estoy hay que sacar creo


        private readonly TPI_DbContext _context;

        public SubastaController(TPI_DbContext context)
        {
            _context = context;
        }

        [HttpGet("/SubastaActiva/{id}")]
        public async Task<ActionResult<SubastaProductosDTO>> GetSubastaActivaProductos(int id)
        {
            var subasta = await _context.Subastas
                .Include(s => s.listaProductos)
                .FirstOrDefaultAsync(s => s.subastaID == id);

            if (subasta == null)
            {
                return NotFound();
            }

            var subastaProductosDTO = new SubastaProductosDTO
            {
                subastaID = subasta.subastaID,
                listaProductos = subasta.listaProductos.Select(p => new ProductoDatosDTO
                {
                    nombreProducto = p.nombreProducto,
                    precioBase = p.precioBase,
                    metodoEntrega = p.metodoEntrega,
                    fechaSolicitud = p.fechaSolicitud,
                    estadoProducto = p.estadoProducto
                }).ToList(),

            };

            return subastaProductosDTO;
        }



    }
}
