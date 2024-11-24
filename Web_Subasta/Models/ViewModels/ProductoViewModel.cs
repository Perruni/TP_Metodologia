using static Core.Entities.Producto;
using System.ComponentModel.DataAnnotations;
using Core.Entities;
using Core.Shared.DTOs.Subastas;
using static Core.Entities.Subasta;

namespace Web_Subasta.Models.ViewModels
{
    public class ProductoViewModel
    {
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }

        public EstadoProducto EstadoProducto { get; set; }

        public EstadoSubasta EstadoSubasta { get; set; }

        public string Descripcion { get; set; }

        public double PrecioBase { get; set; }
        public string MetodoEntrega { get; set; }

        public DateTime FechaSolicitud { get; set; }

        public EstadoSolicitud EstadoSolicitud { get; set; }

        public IFormFile ImagenUrlArchivo { get; set; }

        public List<Producto>? productoUsuario { get; set; } = new List<Producto>();

        //public List<Subasta>? subastaLista { get; set; } = new List<SubastaDTO>();

        public List<Subasta> subastaLista { get; set; }

        public string titulo { get; set; }

        public DateTime fechaInicio { get; set; }

        public DateTime fechaFinalizado { get; set; }

        public int CantidadOfertas { get; set; }

        //Titulo de subasta

        public string imagenUrl { get; set; }
        public string Titulo { get; set; }

        public Subasta Subasta { get; set; }

        public int subastaId { get; set; }

        public Producto Producto { get; set; }

        public int montoOferta { get; set; }


    }
}
