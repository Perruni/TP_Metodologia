using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Entities.Producto;
using Microsoft.AspNetCore.Http;

namespace Core.Shared.DTOs.Producto
{
    public class ProductoDTO
    {
        public string nombreProducto { get; set; }
        public double precioBase { get; set; }
        public string metodoEntrega { get; set; }
        public string descripcion { get; set; }
        public IFormFile imagenUrl { get; set; }


    }
}
