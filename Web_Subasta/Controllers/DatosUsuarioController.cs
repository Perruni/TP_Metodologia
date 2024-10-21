using Core.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Subasta.Models.ViewModels;

namespace Master_API.Controllers
{
    public class DatosUsuarioController : Controller
    {
	/*
		private readonly TPI_DbContext _context;

		public DatosUsuarioController(TPI_DbContext context)
		{
			_context = context;
		}

		public IActionResult DatosUsuario()
        {
            return View();
        }

		[HttpPost]
		public IActionResult DatosUsuario(DatosUsuarioVM modelo)
		{
			if (ModelState.IsValid)
			{

				var datosUsuarios = new Datos_usuario
				{
					usuarioID = 1,
					nombre = modelo.Nombre,
					apellido = modelo.apellido,
					DNI = modelo.dni,
					codigoArea = modelo.CodeArea,
					direccion = modelo.direccion,
					telefono = modelo.Telefono
				};

				
				_context.DatosUsuario.Add(datosUsuarios);
				_context.SaveChanges();

				return RedirectToAction("Activas");
			}

			// Si el modelo no es válido, vuelve a mostrar la vista con los errores // nose como funciona xd
			return View(modelo);
		}
	}
	*/
}
