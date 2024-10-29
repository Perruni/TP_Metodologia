using static Core.Entities.Producto;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Web_Subasta.Models.ViewModels
{
    public class ProductoViewModel
    {
        public int ProductoID { get; set; }
        public string NombreProducto => Producto.nombreProducto;

        public EstadoProducto EstadoProducto { get; set; }
        public string Descripcion => Producto.descripcion;

        public double PrecioBase => Producto.precioBase;
        public string MetodoEntrega { get; set; }

        public DateTime FechaSolicitud { get; set; }

        public EstadoSolicitud EstadoSolicitud { get; set; }

        public IFormFile ImagenUrlArchivo { get; set; }

        public List<Producto>? productoUsuario { get; set; }

        public List<Subasta>? subastaLista { get; set; }

        public string titulo { get; set; }

        public DateTime fechaInicio => Subasta.fechaInicio;

        public DateTime fechaFinalizado=>  Subasta.fechaFinalizado;

        public int CantidadOfertas { get; set; }

        //Titulo de subasta
        public string Titulo => Subasta.titulo;

        public Subasta Subasta { get; set; }

        public int SubastaId { get; set; }

        public Producto Producto { get; set; }


    }
}
