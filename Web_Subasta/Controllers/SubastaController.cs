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

namespace Web_Subasta.Controllers
{
    [Route("/[controller]")]

    public class SubastaController : Controller
    {

        static HttpClient client = new HttpClient();
        private readonly TPI_DbContext _context;



        public SubastaController(TPI_DbContext context)
        {
            _context = context;

            client.BaseAddress = new Uri("https://localhost:7053/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpGet("{subastaID}")]
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


        [HttpGet("Activas")]
        public async Task<IActionResult> Activas()
        {

            List<Subasta> subasta = null;

            var response = await client.GetAsync("Subasta/Activa");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                subasta = JsonSerializer.Deserialize<List<Subasta>>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (subasta != null && subasta != null)
                {
                    var viewModel = new SubastaViewModel
                    {
                        subastaLista = subasta
                    };
                    return View("~/Views/Home/Activas.cshtml", viewModel);
                }

            }
            return NotFound();
        }

        
        [HttpGet("Proximas")]
        public async Task<IActionResult> Proximas()
        {
            List<Subasta> subasta = null;

            var response = await client.GetAsync("Subasta/Proximas");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                 subasta = JsonSerializer.Deserialize<List<Subasta>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (subasta != null && subasta != null)
                {
                    var viewModel = new SubastaViewModel
                    {
                        subastaLista = subasta
                    };
                    return View("~/Views/Home/Proximas.cshtml", viewModel);
                }
            }
            return NotFound();
        }

        [HttpGet("Finalizadas")]
        public async Task<IActionResult> Finalizadas()
        {
            List<Subasta> subasta = null;

            var response = await client.GetAsync("Subasta/Finalizadas");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                subasta = JsonSerializer.Deserialize<List<Subasta>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (subasta != null && subasta != null)
                {
                    var viewModel = new SubastaViewModel
                    {
                        subastaLista = subasta
                    };
                    return View("~/Views/Home/Finalizadas.cshtml", viewModel);
                }
            }
            return NotFound();
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
