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
using Web_Subasta.Services;

namespace Web_Subasta.Controllers
{

    public class SubastaController : Controller
    {

        static HttpClient client = new HttpClient();
        private readonly TPI_DbContext _context;
        private readonly IServiceAPI _service;

        static SubastaController()
        {
            // Configuración del HttpClient en el constructor estático
            client.BaseAddress = new Uri("https://localhost:7053/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public SubastaController(TPI_DbContext context, IServiceAPI serviceAPI)
        {
            _context = context;
            _service = serviceAPI;

            
        }

        [HttpGet("{subastaID}")]
        public async Task<IActionResult> GetSubasta(int SubastaID)
        {
            Subasta? subasta = null;

            subasta = await _service.GetSubasta(SubastaID);


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

            subasta = await _service.GetSubastasActivas();
           

            if (subasta != null)
            {
                var viewModel = new SubastaViewModel
                {
                    subastaLista = subasta
                };
                return View("~/Views/Home/Activas.cshtml", viewModel);
            }

            
            return NotFound();
        }

        
        [HttpGet("Proximas")]
        public async Task<IActionResult> Proximas()
        {
            List<Subasta> subasta = null;

            subasta = await _service.GetSubastasProximas();


            if (subasta != null)
            {
                var viewModel = new SubastaViewModel
                {
                    subastaLista = subasta
                };
                return View("~/Views/Home/Proximas.cshtml", viewModel);
            }


            return NotFound();
        }

        [HttpGet("Finalizadas")]
        public async Task<IActionResult> Finalizadas()
        {
            List<Subasta> subasta = null;

            subasta = await _service.GetSubastasFinalizadas();


            if (subasta != null)
            {
                var viewModel = new SubastaViewModel
                {
                    subastaLista = subasta
                };
                return View("~/Views/Home/Finalizadas.cshtml", viewModel);
            }
            return NotFound();
        }
        

        

    }
}
