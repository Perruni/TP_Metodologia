using Core.Data;
using Core.Shared.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Master_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly TPI_DbContext _context;

        public UsuarioController(TPI_DbContext context)
        {
            _context = context;
        }
        
    }
}
