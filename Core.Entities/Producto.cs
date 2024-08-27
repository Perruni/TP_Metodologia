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
        public bool estadoProducto { get; set; }

        // Foreign Key a Categoria
        public int CategoriaID { get; set; }
        [ForeignKey("CategoriaID")]
        public virtual Categoria Categoria { get; set; }
    }
}
