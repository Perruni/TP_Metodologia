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
using Web_Subasta.Services;
using Web_Subasta.Models.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Web_Subasta.Controllers
{
    [Route("/[controller]")]
    
    public class OfertaController : Controller
    {
        private readonly IServiceAPI _serviceAPI;
        private readonly TPI_DbContext _context;

        public OfertaController(TPI_DbContext context, IServiceAPI serviceAPI)
        {
            _context = context;

            _serviceAPI = serviceAPI;
        }

        
        public IActionResult MisOfertas()
        {
            
            if (!User.Identity.IsAuthenticated)
            {
                
                return RedirectToAction("login", "Usuario");
            }
           
            return View("~/Views/Home/MisOfertas.cshtml");
        }

        [HttpGet("MisOfertas")]
        public async Task<IActionResult> GetUsuarioOf()
        {

            var userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);


            List<Oferta>? oferta = null;

            oferta = await _serviceAPI.GetOfertasUsuario(userID);           


            if (oferta != null)
            {
                var viewModel = new OfertaViewModel
                {
                    ofertasUsuario = oferta
                };
                return View("~/Views/Home/MisOfertas.cshtml", viewModel);//Poner la vista correspondiente
            }
            return NotFound();
        }

        //Esto iria para certificado pero nose en que vista se realizara dejar esto por las dudas
        [HttpGet("{offerID}")]
        public async Task<IActionResult> GetOfertante(int offerID)
        {
            Oferta oferta = null;

            oferta = await _serviceAPI.GetOfertaId(offerID);


            if (oferta != null)
            {
                var viewModel = new OfertaViewModel
                {
                    _oferta = oferta
                };
                return View("~/Views/Home/Activas.cshtml", viewModel);//Poner la vista correspondiente
            }
            return NotFound();
        }


        [HttpGet("Resultados/{subastaID}")]
        public async Task<IActionResult> GetOfertasGanadoras(int subastaID)
        {
            List<Oferta>? oferta = null;

            oferta = await _serviceAPI.GetOfertasGanadoras(subastaID);


            if (oferta != null)
            {
                var viewModel = new OfertaViewModel
                {
                    ofertasUsuario = oferta
                };
                return View("~/Views/Home/Activas.cshtml", viewModel);//Poner la vista correspondiente
            }
            return NotFound();
        }

        [HttpGet("oferta/{productoID}")]
        public async Task<IActionResult> GetOfertaProducto(int productoID)
        {
            int cantidadOfertas = 0;

            cantidadOfertas = await _serviceAPI.GetCantidadOfertas(productoID);


            if (cantidadOfertas != null)
            {
                var viewModel = new OfertaViewModel
                {
                    cantidadOfertas = cantidadOfertas
                };
                return View("~/Views/Home/Activas.cshtml", viewModel);//Poner la vista correspondiente
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> PostOferta([FromForm] OfertaDTO ofertaDto, int productoID)
        {
            

            var userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);


            if (ofertaDto == null)
            {
                return BadRequest("Los datos de la oferta son inválidos");
            }           


            var data = new OfertaDTO
            {                
               montoOferta = ofertaDto.montoOferta
            };

            //Falta pasar id de usuario y porducto al hacer oferta
            var respuesta = await _serviceAPI.AddOferta(data, userID, productoID);

            if (respuesta != null)
            {

                return Ok("Datos enviados correctamente.");// Poner ruta correspondiente
            }
            return NotFound();
        }



    }
}
