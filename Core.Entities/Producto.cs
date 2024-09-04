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
        [Key]
        public int ProductoID { get; set; }
        public string nombreProducto { get; set; }
        public int estadoProducto { get; set; }
        public string descripcion { get; set; }
        public double precioBase { get; set; }
        public int ofertas { get; set; }
        public int habilitacionProducto { get; set; }

        public int usuarioID { get; set; }
        [ForeignKey("usuarioID")]
        public virtual Usuario Usuario { get; set; }
    }
}
