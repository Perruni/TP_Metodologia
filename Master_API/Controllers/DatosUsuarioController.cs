using Core.Busisness;
using Core.Busisness.Interfaces;
using Core.Data.Interface;
using Core.Entities;
using Core.Shared;
using Core.Shared.DTOs.Usuario;
using Core.Shared.DTOs.Producto;
using Microsoft.AspNetCore.Mvc;

namespace Master_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosUsuarioController : Controller
    {

        private readonly IDatosUsuarioBusiness _datosBusiness;
        private readonly IProjectRepository _repository;

        public DatosUsuarioController(IDatosUsuarioBusiness datosoBusiness, IProjectRepository repository)
        {
            _datosBusiness = datosoBusiness;
            _repository = repository;
        }

        [HttpGet("{UserID}")]
        public async Task<ActionResult<Datos_usuario>> GetUserData(int UserID)
        {

            var datos = await _datosBusiness.DatosUsuario(UserID);

            if (datos == null)
            {
                return NotFound();
            }

            return Ok(datos);

        }

        [HttpPost("{userId}")]
        public async Task<ActionResult<Datos_usuario?>> PostDatosUsuario(Datos_usuarioDTO request, int userId)
        {
            // Validación del modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Crear una nueva instancia de Producto
            var nuevoDatos = new Datos_usuario
            {
                usuarioID = userId,
                DNI = request.DNI,
                nombre = request.nombre,
                apellido = request.apellido,
                direccion = request.direccion,
                telefono = request.telefono,
                codigoArea = request.codigoArea,
            };

            // Agregar el nuevo producto al contexto
            await _datosBusiness.AddDatosUsuario(nuevoDatos);

            return Ok(nuevoDatos);

        }
    }
}
