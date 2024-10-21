using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web_Subasta.Models.ViewModels
{
    public class MisProductosVM 
    {

        public int IdProducto { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public double precioBase { get; set; }

        public List<Oferta> cantidadOfertas { get; set; }

        public int estado { get; set; }

        public List<Producto> ListaProductos { get; set; }
       
    }
    
}
