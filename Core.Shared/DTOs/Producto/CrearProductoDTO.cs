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
        public string NombreProducto { get; set; }
        public double PrecioBase { get; set; }
        public string MetodoEntrega { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public EstadoProducto estadoProducto { get; set; }
        public string Descripcion { get; set; }



    }
}
