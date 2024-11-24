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
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

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
                usuarioID = userId

            };

            var respuesta = await _service.AddDatosUsuario(data, userId);


            if (respuesta != null)
            {
                // Autenticamos al usuario después de agregar sus datos
                var user = await _service.GetUsuario(userId); // Obtener el usuario de la base de datos
                if (user != null)
                {
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.usuarioID.ToString()),
                new Claim(ClaimTypes.Name, user.email), // O cualquier otro campo que necesites
            };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    // Iniciar sesión
                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);

                    // Guardamos en la sesión el nombre del usuario y el ID para mostrarlo en la vista
                    HttpContext.Session.SetString("UsuarioID", user.usuarioID.ToString());
                    HttpContext.Session.SetString("Correo : ", user.email);

                    // Redirigir al usuario a la página principal o al área de subastas
                    return RedirectToAction("Activas", "Subasta");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error al enviar los datos.");
                return View("~/Views/Home/DatosUsuario.cshtml", modelo);
            }

            return View("~/Views/Home/DatosUsuario.cshtml", modelo);
        }

    }
}