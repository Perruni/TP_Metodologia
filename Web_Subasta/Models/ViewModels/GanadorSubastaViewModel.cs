namespace Web_Subasta.Models.ViewModels
{
    public class GanadorSubastaViewModel
    {
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioBase { get; set; }
        public string NombreGanador { get; set; }
        public string ContactoGanador { get; set; }
        public string DomicilioGanador { get; set; }
        public string DniGanador { get; set; }
        public string NombreVendedor { get; set; }
        public string ContactoVendedor { get; set; }
        public string DomicilioVendedor { get; set; }
        public string DniVendedor { get; set; }
        public string TituloSubasta { get; set; }
        public DateTime FechaFinalizadoSubasta { get; set; }

       public string imagenUrl { get; set; }
    
        public int SubastaID { get; set; }
    }
}
