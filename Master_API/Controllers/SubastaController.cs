using Core.Busisness.Interfaces;
using Core.Data;
using Core.Entities;
using Core.Shared.DTOs.Producto;
using Core.Shared.DTOs.Subastas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Master_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubastaController : ControllerBase
    {

        private readonly ISubastaBusiness _subastaBusiness;

        public SubastaController(ISubastaBusiness subastaBusiness)
        {
            _subastaBusiness = subastaBusiness;

        }

        [HttpGet("/Activa")]
        public async Task<ActionResult<Subasta>> GetSubastaActiva()
        {
            var subasta = await _subastaBusiness.GetSubastasActivas();

            if (subasta == null)
            {
                return NotFound();
            }

            return Ok(subasta);
        }
    }
}
