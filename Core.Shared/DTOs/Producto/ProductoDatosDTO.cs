using Core.Entities;
using Core.Shared.DTOs.Usuario;
using static Core.Entities.Producto;

namespace Core.Shared.DTOs.Producto
{

    //Trae los datos del producto y del usuario
    public class ProductoDatosDTO
    {
        public string? nombreProducto { get; set; }
        public double precioBase { get; set; }
        public string? metodoEntrega { get; set; }
        public DateTime fechaSolicitud { get; set; }
        public string? descripcion { get; set; }
        public EstadoProducto estadoProducto { get; set; }
        public UsuarioDTO? usuario { get; set; }
    }
}
