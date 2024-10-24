using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Notas:
 * ID de producto
 * Nombre
 * Estado
 */


namespace Core.Entities
{
    [Table("Productos")]
    public class Producto
    {
        public int ProductoID;

        [Key]
        public int productoID { get; set; }
        public string nombreProducto { get; set; }
        public EstadoProducto estadoProducto { get; set; }
        public string descripcion { get; set; }
        public double precioBase { get; set; }
        public string metodoEntrega { get; set; }
        public DateTime fechaSolicitud { get; set; }
        public EstadoSolicitud estadoSolicitud { get; set; }

        public int? usuarioID { get; set; }
        [ForeignKey("usuarioID")]
        public virtual Usuario? Usuario { get; set; }

        public int? subastaID { get; set; }
        [ForeignKey("subastaID")]
        public virtual Subasta? Subasta { get; set; }

        public List<Oferta>? listaOfertas { get; set; }

        public enum EstadoProducto
        {
            EnSubasta = 1,
            Vendido = 2,
            NoVendido = 3,
            EnRevision = 4,

        }

        public enum EstadoSolicitud
        {
            Pendiente = 1,
            Aprobado = 2,
            Rechazado = 3,
            Cancelado = 4,
        }
    }
}
