using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("Facturas")]

    public class Factura
    {
        [Key]
        public int facturaId { get; set; }
        public string metodoPago { get; set; }
        public DateTime fechaEmision { get; set; }
        public int tipoFactura { get; set; }
        public int dni { get; set; }
        [ForeignKey("dni")]
        public virtual Usuario Usuario { get; set; }
        public int montoOferta {  get; set; }
        [ForeignKey("montoOferta")]
        public Oferta Oferta { get; set; }
    }
}
