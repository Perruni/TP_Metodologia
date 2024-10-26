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
using System.Text.Json;
using System.Collections.Generic;
using Core.Shared.APITest;

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
                var subastaResponse = JsonSerializer.Deserialize<Subasta>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

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
            try
            {
                // Realiza la solicitud a la API
                HttpResponseMessage response = await client.GetAsync("Subasta/Activa");
                response.EnsureSuccessStatusCode(); // Lanza una excepción si el código de estado no es exitoso

                // Lee el contenido de la respuesta
                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserializa el JSON a un objeto de tipo SubastaResponse
                var subastaResponse = JsonSerializer.Deserialize<SubastaResponse>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                // Verifica si la deserialización fue exitosa y si hay valores
                if (subastaResponse != null && subastaResponse.Values != null)
                {
                    // Crea un modelo de vista con la lista de subastas deserializadas
                    var viewModel = new SubastaViewModel
                    {
                        subastaListaAPI = subastaResponse.Values // Asigna la lista de subastas deserializadas
                    };

                    // Devuelve la vista con el modelo de vista
                    return View("~/Views/Home/Activas.cshtml", viewModel);
                }
                else
                {
                    // Si la respuesta o los valores son nulos, devuelve un error 404
                    return NotFound("La respuesta de la API no contiene valores.");
                }
            }
            catch (HttpRequestException e)
            {
                // Manejo de excepción para errores de solicitud HTTP
                return StatusCode(500, $"Error al llamar a la API: {e.Message}");
            }
            catch (Exception ex)
            {
                // Manejo de excepción general para cualquier otro error
                return StatusCode(500, $"Error al procesar la solicitud: {ex.Message}");
            }
        }

        /*[HttpGet("Activa")]
        public async Task<IActionResult> Activas()
        {

            List<Subasta> subasta = null;


            var response = await client.GetAsync("Subasta/Activa");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var subastaResponse = JsonConvert.DeserializeObject<List<SubastaResponse>> (jsonResponse);

                // Verifica si la deserialización fue exitosa y si hay valores
                if (subastaResponse != null && subastaResponse.Values != null)
                {
                    var viewModel = new SubastaViewModel
                    {
                        subastaListaDTO = subastaResponse.values // Asigna la lista de subastas deserializadas
                    };
                    return View("~/Views/Home/Activas.cshtml", viewModel);
                }

            }
            return NotFound();
        }*/

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
