using Core.Entities;
using static Core.Entities.Producto;

namespace Core.Shared.DTOs.Producto
{
    public class ProductoDTO
    {
        public string NombreProducto { get; set; }
        public double PrecioBase { get; set; }
        public string MetodoEntrega { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Descripcion { get; set; }
        public EstadoProducto EstadoProducto { get; set; }
        

    }
}
