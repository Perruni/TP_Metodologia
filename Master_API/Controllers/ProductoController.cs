using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Master_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet("{ProductoID}")]
        public async Task<ActionResult<Productos>> GetProduct(int ProductoID)
        {
            var product = await _context.Products.FindAsync(ProductoID);

            if (product == null)
            {
                return GetProduct();
            }

            return product;
        }
    }
}
