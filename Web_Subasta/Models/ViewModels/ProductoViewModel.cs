using static Core.Entities.Producto;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Web_Subasta.Models.ViewModels
{
    public class ProductoViewModel
    {
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }

        public EstadoProducto EstadoProducto { get; set; }
        public string Descripcion { get; set; }

        public double PrecioBase { get; set; }
        public string MetodoEntrega { get; set; }

        public DateTime FechaSolicitud { get; set; }

        public EstadoSolicitud EstadoSolicitud { get; set; }

        public IFormFile imagenUrl { get; set; }

        public List<Producto>? productoUsuario { get; set; }

        public List<Subasta>? subastaLista { get; set; }

        public string titulo { get; set; }
    }
}
