using System;
using System.Collections.Generic;
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
    internal class Producto
    {
        public int idProducto { get; set; }
        public string nombreProducto {  get; set; }
        public bool estadoProducto {  get; set; }
    }
}
