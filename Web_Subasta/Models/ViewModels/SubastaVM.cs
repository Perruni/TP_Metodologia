using Core.Entities;

namespace Web_Subasta.Models.ViewModels
{
    public class SubastaVM
    {
        //El View Model utiliza el objeto subasta para enteder que es uan subasta
        public Subasta? _subasta { get; set; }

        public List<Producto>? productoLista { get; set; }

        public Producto? _producto { get; set; }

        //Esto no va
        public int subastaID { get; set; }
        public string titulo { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinalizado { get; set; }
        public int estadoSubasta { get; set; }
        public int metodosdePago { get; set; }
        //Hasta aca
        public List<Producto>? listaProductos { get; set; }

    }
}
