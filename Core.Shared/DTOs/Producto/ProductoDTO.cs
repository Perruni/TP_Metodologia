using Core.Entities;
using static Core.Entities.Producto;

namespace Core.Shared.DTOs.Producto
{
    public class ProductoDTO
    {
        public string nombreProducto { get; set; }
        public double precioBase { get; set; }
        public string metodoEntrega { get; set; }
        public DateTime fechaSolicitud { get; set; }
        public string descripcion { get; set; }
        public EstadoProducto estadoProducto { get; set; }
        

    }
}
