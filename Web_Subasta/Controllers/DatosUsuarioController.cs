using Core.Busisness.Interfaces;
using Core.Data;
using Core.Data.Interface;
using Core.Entities;
using Core.Shared.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Web_Subasta.Models.ViewModels;
using Web_Subasta.Services;

namespace Web_Subasta.Controllers
{
    public class DatosUsuarioController : Controller
    {

        private readonly TPI_DbContext _context;
        private readonly IServiceAPI _service;

        public DatosUsuarioController(TPI_DbContext context, IServiceAPI serviceAPI)
        {
            _context = context;
            _service = serviceAPI;

        }

        [HttpGet]
        public async Task<IActionResult> GetDatosUsuario(int userId)
        {
            Datos_usuario datosUsuario;          

            datosUsuario = await _service.GetDatosUsuario(userId);


            if (datosUsuario != null)
            {
                var viewModel = new DatosUsuarioVM
                {
                    _datosUsuario = datosUsuario,
                };
                return View("~/Views/Home/Activas.cshtml", viewModel);
            }

            return NotFound();


        }


        [HttpPost]
        public async Task<IActionResult> AddDatosUsuario(int userId, DatosUsuarioVM modelo)
        {

            if (!ModelState.IsValid)
            {
                return View("~/Views/Home/DatosUsuario.cshtml", modelo);
            }

            var data = new Datos_usuarioDTO
            {
                DNI = modelo.dni,
                nombre = modelo.nombre,
                apellido  = modelo.apellido,
                direccion = modelo.direccion,
                telefono = modelo.telefono,
                codigoArea = modelo.codigoArea,

            };

            var respuesta = await _service.AddDatosUsuario(data, userId);

            if (respuesta != null)
            {
                return View("DatosUsuario");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error al enviar los datos.");
                return View("~/Views/Home/DatosUsuario.cshtml", modelo);
            }



        }

    }

}
