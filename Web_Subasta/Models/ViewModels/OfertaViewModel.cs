using Core.Entities;

namespace Web_Subasta.Models.ViewModels
{
    public class OfertaViewModel
    {
        public int OfertaID { get; set; }
        public double Monto { get; set; }
        public int UsuarioID { get; set; }
        public DateTime FechaOferta { get; set; }
        public Oferta? _oferta { get; set; }

        public List<Oferta>? ofertasUsuario { get; set; }

        public int cantidadOfertas { get; set; }


    }
}
