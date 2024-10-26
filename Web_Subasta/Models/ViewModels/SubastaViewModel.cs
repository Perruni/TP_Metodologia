using Core.Entities;

namespace Web_Subasta.Models.ViewModels
{
    public class SubastaViewModel
    {
        //El View Model utiliza el objeto subasta para enteder que es una subasta
        public Subasta? subasta { get; set; }

        public List<Producto>? productoLista { get; set; }

        public Producto? _producto { get; set; }

        public string ImagenUrl { get; set; }
        public string NombreProducto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PrecioBase { get; set; }
        public int CantidadOfertas { get; set; }
        public string Descripcion { get; set; }

    }
}
