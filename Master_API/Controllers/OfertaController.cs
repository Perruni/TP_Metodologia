using Core.Busisness;
using Core.Busisness.Interfaces;
using Core.Data;
using Core.Data.Interface;
using Core.Entities;
using Core.Shared.DTOs.Oferta;
using Core.Shared.DTOs.Producto;
using Core.Shared.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/*
        public Task<Oferta> AddOferta(Oferta oferta);
        public Task<Oferta> DeleteOferta(int ofertaID);
        public Task<Oferta> GetOfertaPorId(int ofertaID);
        public Task<Oferta> GetOfertaGanadora(int porductoID);
        public Task<List<Oferta>> GetOfertasGanadoras(int subastaID);
        public Task<List<Oferta>> GetOfertasUsuario(int usuarioID);
        public Task<List<Oferta>> GetProductoOfertas(int productoID);
        public Task<List<Oferta>> GetTodasLasOfertas();
 */

namespace Master_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaController : Controller
    {
        private readonly IOfertaBussiness _ofertaBusiness;

        public OfertaController(IOfertaBussiness ofertaBussiness)
        {
            _ofertaBusiness = ofertaBussiness;
        }

        
        [HttpGet("Usuario/{userID}")]
        public async Task<ActionResult<Oferta>> GetUsuarioOfertas(int userID)
        {
            var oferta = await _ofertaBusiness.GetOfertasUsuario(userID);
                

            if (oferta == null)
            {
                return NotFound();
            }           

            return Ok(oferta);
        }

        [HttpGet("ID/{offerID}")]
        public async Task<ActionResult<Oferta>> GetOfertaID(int offerID)
        {
            var oferta = await _ofertaBusiness.GetOfertaId(offerID);


            if (oferta == null)
            {
                return NotFound();
            }

            return Ok(oferta);
        }

        [HttpGet("{productoID}")]
        public async Task<ActionResult<Oferta>> GetCantidadOferta(int productoID)
        {
            var oferta = await _ofertaBusiness.GetCantidadOfertas(productoID);


            if (oferta == null)
            {
                return NotFound();
            }

            return Ok(oferta);
        }

        [HttpGet("Ofertas")]
        public async Task<ActionResult<Oferta>> GetListaOfertas()
        {
            var oferta = await _ofertaBusiness.GetTodasLasOfertas();


            if (oferta == null)
            {
                return NotFound();
            }

            return Ok(oferta);
        }

        [HttpPost("{userID}/{productoID}")]
        public async Task<ActionResult<OfertaDTO>> PostOfertas(OfertaDTO request, int userID, int productoID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nuevaOferta = new Oferta
            {
                montoOferta = request.montoOferta,
                fechaOferta = DateTime.Now,
                estadoOferta = Oferta.EstadoOferta.Pendiente,
                usuarioID = userID,
                productoID = productoID
            };

            // Agregar el nuevo producto al contexto
            await _ofertaBusiness.AddOferta(nuevaOferta);

            return CreatedAtAction(nameof(GetOfertaID), new { offerID = nuevaOferta.ofertaID }, nuevaOferta);

        }

        

        [HttpDelete("{userID}/{offerID}")]
        public async Task<ActionResult<Oferta?>> DeleteOferta(int userID, int offerID)
        {

            var oferta =  await _ofertaBusiness.GetOfertaId(offerID);
            

            if (userID != oferta.usuarioID)
            {
                return Forbid();

            }

            if (oferta == null)
            {

                return NotFound();

            }

            await _ofertaBusiness.DeleteOferta(offerID);

            return NoContent();

        }

    }
}
