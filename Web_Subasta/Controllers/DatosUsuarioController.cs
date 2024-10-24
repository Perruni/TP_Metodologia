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

namespace Master_API.Controllers
{
    public class DatosUsuarioController : Controller
    {

        private readonly IDatosUsuarioBusiness _datosBusiness;
        private readonly HttpClient _httpClient;

        public DatosUsuarioController(IDatosUsuarioBusiness datosBusiness, HttpClient httpClient)
        {
            _datosBusiness = datosBusiness;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7073/");
        }

        [HttpGet]
        public IActionResult AddDatosUsuario(int userId)
        {
            var model = new DatosUsuarioVM
            {
                usuarioID = userId 
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddDatosUsuario(int userId, DatosUsuarioVM modelo)
        {
        
                var datosUsuarios = new Datos_usuarioDTO
                {
                    DNI = modelo.dni,
                    nombre = modelo.nombre,
                    apellido = modelo.apellido,
                    direccion = modelo.direccion,
                    telefono = modelo.telefono,
                    codigoArea = modelo.codigoArea,
                    usuarioID = userId,
                };

                // Construir la URL para llamar a la API
                var apiUrl = $"api/DatosUsuario/{userId}";
                var jsonContent = JsonConvert.SerializeObject(datosUsuarios);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Hacer la solicitud POST a la API
                var response = await _httpClient.PostAsync(apiUrl, httpContent);

                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("Activas", "Home");
                }

    
                ModelState.AddModelError("", "Error al guardar los datos adicionales.");
            

       
            return View(modelo);
        }

    }

}
