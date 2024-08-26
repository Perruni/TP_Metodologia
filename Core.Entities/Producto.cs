using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class Producto
    {
        [Key]
        public int ProductoID { get; set; }
        public string nombreProducto {  get; set; }
        public bool estadoProducto {  get; set; }

    }
}
