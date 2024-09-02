using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("ListaProductos")]
    public class ListaProducto
    {
        [Key]
        public int idListaProductos { get; set; }
        public string nombreProducto { get; set; }

        public int categoriaID { get; set; }
        [ForeignKey("categoriaID")]
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    }
}
