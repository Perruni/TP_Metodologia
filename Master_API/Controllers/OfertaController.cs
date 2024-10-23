using Core.Busisness.Interfaces;
using Core.Data;
using Core.Data.Interface;
using Core.Entities;
using Core.Shared.DTOs.Producto;
using Core.Shared.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Master_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaController : Controller
    {
        private readonly IOfertaBussiness _ofertaBusiness;
        private readonly IProjectRepository _repository;

        public OfertaController(IOfertaBussiness ofertaBussiness, IProjectRepository repository)
        {
            _ofertaBusiness = ofertaBussiness;
            _repository = repository;
        }

        
        [HttpGet("/MisOfertas/{userID}")]
        public async Task<ActionResult<Oferta>> GetUsuarioOfertas(int userID)
        {
            var oferta = await _ofertaBusiness.GetOfertasUsuario(userID);
                

            if (oferta == null)
            {
                return NotFound();
            }           

            return Ok(oferta);
        }
    }
}
