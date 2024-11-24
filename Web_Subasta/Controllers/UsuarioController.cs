using Core.Busisness.Interfaces;
using Core.Busisness;
using Core.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Web_Subasta.Models.ViewModels;
using Web_Subasta.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Proyecto.Core.Business;
using Microsoft.Identity.Client;




namespace Web_Subasta.Controllers
{
    [Route("[controller]")]

    public class UsuarioController : Controller
    {

        private readonly IServiceAPI _serviceAPI;
        private readonly TPI_DbContext _context;
        private readonly IUsuarioBussiness _userBusiness;

        public UsuarioController(TPI_DbContext context, IServiceAPI serviceAPI, IUsuarioBussiness usuarioBussiness)
        {
            _context = context;
            _serviceAPI = serviceAPI;
            _userBusiness = usuarioBussiness;

        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            if (User.Identity!.IsAuthenticated) return RedirectToAction("Activas", "Subasta");
            return View("~/Views/Acount/register.cshtml");
        }


        [HttpPost("Register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_userBusiness.CreateUser(model.Email, model.Password))
                {
                    ViewData["ExistUser"] = "El usuario ya existe";
                    return View("~/Views/Acount/register.cshtml",model);
                }

                return RedirectToAction("Login" , "Usuario");
            }
            return View("~/Views/Acount/register.cshtml",model);
        }


        [HttpGet("Login")]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated) return RedirectToAction("Activas", "Subasta");
            return View("~/Views/Acount/login.cshtml");
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userBusiness.ObtainUsuario(model.email);
                if (user != null)
                {
                    byte[] hashPassword = CryptoHelper.HashPassword(model.Password, user.Salt);
                    if (user.HashPassword.SequenceEqual(hashPassword))
                    {
                        List<Claim> claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.usuarioID.ToString())
                        };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        AuthenticationProperties properties = new AuthenticationProperties()
                        {
                            AllowRefresh = true,
                        };
                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            properties
                            );
                        return RedirectToAction("Activas", "Subasta");
                    }
                }
                ViewData["LoginError"] = "Usuario o contraseña incorrecta";
            }
            return View("~/Views/Acount/login.cshtml",model);
            
        }


        //[HttpGet("login")]
        //public IActionResult Login(int userId)
        //{
        //    var model = new DatosUsuarioVM
        //    {
        //        userId = userId
        //    };

        //    return View("~/Views/Acount/login.cshtml");

        //}




        [HttpGet("Usuario/{userID}")]
        public async Task<IActionResult> GetUsuario(int userID)
        {
            if (userID <= 0)
            {
                ModelState.AddModelError(string.Empty, "El ID de usuario no es válido.");
                return BadRequest(ModelState);
            }

            var usuario = await _serviceAPI.GetUsuario(userID);

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Error al obtener los datos del usuario.");
                return View("Login");
            }

            return View("Activas", usuario);
        }


        /*[HttpPost]
        public async Task<IActionResult> PostUsuario(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("register", model);
            }

            var data = new Usuario
            {
                email = model.Email,
                contrasenia = model.Contrasenia,
            };

            var usuario = await _serviceAPI.AddUsuario(data);

            if (usuario != null)
            {
                return RedirectToAction("DatosUsuario", new { userId = usuario.usuarioID });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error al registrar el usuario.");
                return View("Register", model);
            }
        }*/

        [HttpGet]
        public IActionResult DatosUsuario(int userId)
        {
            var model = new DatosUsuarioVM
            {
                userId = userId
            };

            return View("~/Views/Home/DatosUsuario.cshtml");
        }

        /*[HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUsuario(int userId, [FromBody] UsuarioDTO usuarioDto)
        {
            if (usuarioDto == null || userId <= 0)
            {
                return BadRequest("Datos inválidos.");
            }

            var usuario = new Usuario
            {
                usuarioID = userId,
                email = usuarioDto.email,
                contrasenia = usuarioDto.contrasenia
            };

            var resultado = await _serviceAPI.UpdateUsuario(usuario, userId);

            if (resultado == null)
            {
                return NotFound("No se pudo actualizar el usuario.");
            }

            return NoContent();
        }*/

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUsuario(int userId)
        {
            if (userId != null)
            {
                return BadRequest("ID de usuario inválido.");
            }

            var usuario = await _serviceAPI.GetUsuario(userId);

            if (usuario == null)
            {
                return NotFound("El usuario no fue encontrado.");
            }

            var resultado = await _serviceAPI.Deleteusuario(userId);

            if (resultado != null)
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Error al eliminar el usuario.");
            }
        }
    }

}
