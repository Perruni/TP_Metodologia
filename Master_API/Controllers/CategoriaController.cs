using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Master_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        [Route("/Categoria/")]
        public IActionResult GetAllCategorias()
        {
            var categorias = _categoriaBusiness.GetCategorias();

            return Ok(categorias);
        }

        [HttpGet]
        [Route("/Categoria/{CategoriaID}")]
        public IActionResult GetAllCategorias(int CategoriaID)
        {
            var categoriaID = _categoriaBusiness.GetCategoriasID(CategoriaID);

            return Ok(categoriaID);
        }

        [HttpPost]
        [Route("")]
    }
    
}

