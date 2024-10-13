using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("Certificado")]

    public class Certificado
    {
        [Key]
        public int certificadoId { get; set; }
        public string metodoPago { get; set; }
        public DateTime fechaEmision { get; set; }
        public int productoID { get; set; }
        [ForeignKey("productoID")]
        public virtual Producto Producto { get; set; }

    }
}
