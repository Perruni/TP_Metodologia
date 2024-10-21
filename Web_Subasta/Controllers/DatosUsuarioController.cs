using Core.Busisness.Interfaces;
using Core.Data;
using Core.Data.Interface;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Subasta.Models.ViewModels;

namespace Master_API.Controllers
{
    public class DatosUsuarioController : Controller
    {

        private readonly IDatosUsuarioBusiness _datosBusiness;

        public DatosUsuarioController(IDatosUsuarioBusiness datosBusiness)
        {
            _datosBusiness = datosBusiness;
           
        }

        public IActionResult GetDatosUsuario()
        {
            return View();
        }

		[HttpPost]
		public IActionResult AddDatosUsuario(DatosUsuarioVM modelo)
		{
			if (ModelState.IsValid)
			{

				var datosUsuarios = new Datos_usuario
				{
					usuarioID = 3,
					nombre = modelo.Nombre,
					apellido = modelo.apellido,
					DNI = modelo.dni,
					codigoArea = modelo.CodeArea,
					direccion = modelo.direccion,
					telefono = modelo.Telefono
				};

				
				_datosBusiness.AddDatosUsuario(datosUsuarios);				

				return RedirectToAction("Activas");
			}

			// Si el modelo no es válido, vuelve a mostrar la vista con los errores // nose como funciona xd
			return View("Activas");
		}
	}
	
}
