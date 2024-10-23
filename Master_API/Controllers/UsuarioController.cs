using Core.Busisness;
using Core.Busisness.Interfaces;
using Core.Data;
using Core.Entities;
using Core.Shared.DTOs.Producto;
using Core.Shared.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Master_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBussiness _usuarioBusiness;

        public UsuarioController(IUsuarioBussiness usuarioBusiness)
        {
            _usuarioBusiness = usuarioBusiness;

        }

        [HttpGet("{UsuarioID}")]
        public async Task<ActionResult<Usuario>> GetUserID(int UsuarioID)
        {

            var usuario = await _usuarioBusiness.GetUsuario(UsuarioID);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);

        }

        [HttpPost]
        public async Task<ActionResult<Usuario?>> PostUsuario(UsuarioDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);           }


            var nuevoUsuario = new Usuario
            {
                email = request.email,
                contrasenia = request.contrasenia
            };

            await _usuarioBusiness.AddUsuario(nuevoUsuario);

            return CreatedAtAction(nameof(GetUserID), new { UsuarioID = nuevoUsuario.usuarioID }, nuevoUsuario);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<Usuario?>> PutUsuario(UsuarioDTO request, int userId)
        {

            var usuario = await _usuarioBusiness.GetUsuario(userId);


            if (userId != usuario.usuarioID)
            {
                return Forbid();

            }


            if(usuario == null)
            {

            return NotFound(); 
            
            }

            usuario.email = request.email;
            usuario.contrasenia = request.contrasenia;

            await _usuarioBusiness.UpdateUsuario(usuario);

            return CreatedAtAction(nameof(GetUserID), new { UsuarioID = usuario.usuarioID }, usuario);

        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult<Usuario?>> DeleteUsuario(int userId)
        {

            var usuario = await _usuarioBusiness.GetUsuario(userId);


            if (userId != usuario.usuarioID)
            {
                return Forbid();

            }


            if (usuario == null)
            {

                return NotFound();

            }           

            await _usuarioBusiness.Deleteusuario(userId);

            return Ok();

        }
    }

    
}
