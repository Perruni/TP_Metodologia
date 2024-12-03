using Core.Entities;

namespace Web_Subasta.Models.ViewModels
{
    public class GanadoresFiltradosViewModel
    {
        public IEnumerable<GanadorSubastaViewModel> Ganadores { get; set; }

        public IEnumerable<Subasta> SubastasFinalizadas { get; set; }
        public int? SubastaSeleccionadaID { get; set; }

       
    }
}
