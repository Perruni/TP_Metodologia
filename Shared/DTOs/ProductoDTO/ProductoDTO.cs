using Core.Entities;

namespace Master_API.DTOs.ProductoDTO
{
    public class ProductoDTO
    {
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public double PrecioBase { get; set; }
        public string MetodoEntrega { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int EstadoProducto { get; set; }

        /*public Datos_usuarioDTO DatosUsuario { get; set; }*/

    }
}
