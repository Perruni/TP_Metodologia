using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("Datos_vendedor")]
    public class Datos_vendedor
    {
        [Key]
        [Column(Order = 0)]
        public string DNI { get; set; }

        [Key]
        [Column(Order = 1)]
        public int productoID { get; set; }

        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public int codigoArea { get; set; }

        [ForeignKey("productoID")]
        public virtual Producto Producto { get; set; }
    }

    public class DatosVendedorId
    {
        [Required]
        public string DNI { get; set; }

        [Required]
        public int ProductoID { get; set; }
    }
}

