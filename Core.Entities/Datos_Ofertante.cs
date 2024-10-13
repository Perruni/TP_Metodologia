using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("Datos_ofertante")]
    public class Datos_ofertante
    {
        [Key]
        [Column(Order = 0)]
        public string DNI { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ofertaID { get; set; }

        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public int codigoArea { get; set; }

        [ForeignKey("ofertaID")]
        public virtual Oferta Oferta { get; set; }
    }

    public class DatosOfertanteId
    {
        [Required]
        public string DNI { get; set; }

        [Required]
        public int OfertaID { get; set; }
    }
}
