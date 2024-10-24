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

        [HttpGet("/Proximas")]
        public async Task<ActionResult<Subasta>> GetSubastaProxima()
        {
            var subasta = await _subastaBusiness.GetSubastasProximas();

            if (subasta == null)
            {
                return NotFound();
            }

            return Ok(subasta);
        }

        [HttpGet("/Finalizadas")]
        public async Task<ActionResult<Subasta>> GetSubastaFinalizada()
        {
            var subasta = await _subastaBusiness.GetSubastasFinalizadas();

            if (subasta == null)
            {
                return NotFound();
            }

            return Ok(subasta);
        }

        [HttpGet("{subastaID}")]
        public async Task<ActionResult<Subasta>> GetSubastaID(int subastaID)
        {
            var subasta = await _subastaBusiness.GetSubasta(subastaID);

            if (subasta == null)
            {
                return NotFound();
            }

            return Ok(subasta);
        }

        [HttpGet("Productos/{subastaID}")]
        public async Task<ActionResult<Subasta>> GetSubastaProductos(int subastaID) 
        {

            var subasta = await _subastaBusiness.GetSubastaProductos(subastaID);

            if (subasta == null)
            {
                return NotFound();
            }

            return Ok(subasta);

        }

    }
}
