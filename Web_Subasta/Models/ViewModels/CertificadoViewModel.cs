using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web_Subasta.Models.ViewModels
{
    public class CertificadoViewModel
    {
        public string NumeroCertificado { get; set; }
        public string FechaEmision { get; set; }
        public string NombreSubasta { get; set; }
        public int NumeroSubasta { get; set; }
        public string FechaFinalizacion { get; set; }
        public string NombreGanador { get; set; }
        public string ContactoGanador { get; set; }
        public string DniGanador { get; set; }
        public string DomicilioGanador { get; set; }
        public string NombreVendedor { get; set; }
        public string ContactoVendedor { get; set; }
        public string DniVendedor { get; set; }
        public string DomicilioVendedor { get; set; }
        public List<Producto> Productos { get; set; }
        public string FechaAdjudicacion { get; set; }
        public string MetodoPago { get; set; }
        public decimal PrecioFinal { get; set; }
        public string ModoEntrega { get; set; }
    }
}
