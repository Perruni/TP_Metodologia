using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web_Subasta.Models.ViewModels
{
    public class CertificadoViewModel
    {
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public double PrecioBase { get; set; }
        public string MetodoEntrega { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string ImagenUrl { get; set; }

        // Datos de la Subasta
        public string TituloSubasta { get; set; }
        public DateTime FechaFinalizadoSubasta { get; set; }

        public string MetodoPago { get; set; }

        // Datos del Ganador
        public string NombreGanador { get; set; }
        public string ContactoGanador { get; set; }
        public string DniGanador { get; set; }
        public string DomicilioGanador { get; set; }

        // Datos del Vendedor
        public string NombreVendedor { get; set; }
        public string ContactoVendedor { get; set; }
        public string DniVendedor { get; set; }
        public string DomicilioVendedor { get; set; }
    }
}
