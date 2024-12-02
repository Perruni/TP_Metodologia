using System;

namespace GestorSubastas.Helper
{
    public class ProductoConOferta
    {
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public double PrecioBase { get; set; }
        public estadoProducto EstadoProducto { get; set; }
        public decimal MontoOferta { get; set; }
        public decimal MontoOfertaMultiplicado { get; set; }
    }

    public enum estadoProducto
    {
        EnSubasta = 1,
        Vendido = 2,
        NoVendido = 3,
        EnRevision = 4,

    }
}
