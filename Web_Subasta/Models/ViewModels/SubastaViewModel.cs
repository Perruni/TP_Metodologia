using Core.Entities;
using Core.Shared.DTOs.Subastas;
using static Core.Entities.Subasta;

namespace Web_Subasta.Models.ViewModels
{
    public class SubastaViewModel
    {
        //El View Model utiliza el objeto subasta para enteder que es una subasta
        public Subasta? subasta { get; set; }

        public List<Subasta>? subastaLista { get; set; }
        public List<SubastaDTO>? subastaListaDTO { get; set; } = new List<SubastaDTO>();
        public List<Producto>? productoLista { get; set; }
        public Producto? _producto { get; set; }
        public string ImagenUrl { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioBase { get; set; }
        public int CantidadOfertas { get; set; }
        public string Descripcion { get; set; }
        public int subastaID { get; set; }
        public string titulo { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinalizado { get; set; }
        public EstadoSubasta estadoSubasta { get; set; }
        public MetodosdePago metodosdePago { get; set; }

    }
}
