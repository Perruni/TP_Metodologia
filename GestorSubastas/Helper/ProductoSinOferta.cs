using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Entities.Producto;

namespace GestorSubastas.Helper
{
    public class ProductoSinOferta
    {

        public int productoID { get; set; }
        public string? nombreProducto { get; set; }
        public double precioBase {  get; set; }
        public EstadoProducto estadoProducto { get; set; }

        public enum EstadoProducto
        {
            EnSubasta = 1,
            Vendido = 2,
            NoVendido = 3,
            EnRevision = 4,

        }


    }
}
