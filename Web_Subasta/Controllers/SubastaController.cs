using Core.Data;
using Core.Entities;
using Core.Shared;
using Core.Shared.DTOs.Producto;
using Core.Shared.DTOs.Subastas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.Http;
using System.Net.Http.Headers;
using Web_Subasta.Models.ViewModels;
using Newtonsoft.Json;

namespace Master_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubastaController : Controller
    {

        static HttpClient client = new HttpClient();
        private readonly TPI_DbContext _context;



        public SubastaController(TPI_DbContext context)
        {
            _context = context;

            // Configura el BaseAddress solo una vez en el constructor
            client.BaseAddress = new Uri("https://localhost:7073/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpGet("Subasta/{subastaID}")]
        public async Task<IActionResult> GetSubasta(int SubastaID)
        {
            Subasta subasta = null;

            HttpResponseMessage response = await client.GetAsync($"api/Subasta/{SubastaID}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                subasta = JsonConvert.DeserializeObject<Subasta>(jsonResponse);

            }

            if (subasta == null)
            {
                return NotFound();
            }
            return Ok(subasta);
        }


        [HttpGet("Subasta/Productos/{subastaID}")]
        public async Task<IActionResult> GetProductoSubasta(int SubastaID)
        {
            Subasta subasta = null;

            HttpResponseMessage response = await client.GetAsync($"api/Subasta/Productos/{SubastaID}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                subasta = JsonConvert.DeserializeObject<Subasta>(jsonResponse);

            }

            if (subasta == null)
            {
                return NotFound();
            }
            return Ok(subasta);
        }




        [HttpGet("Activa")]
        public async Task<IActionResult> Activas()
        {

            List<Subasta> subasta = null;


            var response = await client.GetAsync("Subasta/Activa");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var subastaResponse = JsonConvert.DeserializeObject<SubastaResponse>(jsonResponse);

                // Verifica si la deserialización fue exitosa y si hay valores
                if (subastaResponse != null && subastaResponse.Values != null)
                {
                    var viewModel = new SubastaViewModel
                    {
                        subastaListaDTO = subastaResponse.Values // Asigna la lista de subastas deserializadas
                    };
                    return View("~/Views/Home/Activas.cshtml", viewModel);
                }

            }
            return NotFound();
        }

        /*
        [HttpGet("Proximas")]
        public async Task<IActionResult> Proximas()
        {
            var response = await client.GetAsync("Subasta/Proximas");
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
            var response = await client.GetAsync("Subasta/Finalizadas");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var subasta = JsonSerializer.Deserialize<Subasta>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return Ok(subasta);
            }
            return NotFound();
        }
        */

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
