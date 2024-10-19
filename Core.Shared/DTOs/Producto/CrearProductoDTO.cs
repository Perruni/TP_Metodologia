using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Entities.Producto;

namespace Core.Shared.DTOs.Producto
{
    public class CrearProductoDTO
    {
        public string nombreProducto { get; set; }
        public double precioBase { get; set; }
        public string metodoEntrega { get; set; }
        public string descripcion { get; set; }



    }
}
