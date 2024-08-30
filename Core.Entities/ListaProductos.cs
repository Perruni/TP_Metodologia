using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ListaProductos
    {
        [Key]
        public int IdListaProductos { get; set; }
        public string NombreProducto { get; set; }

        public int CategoriaID { get; set; }
        [ForeignKey("CategoriaID")]
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    }
}
