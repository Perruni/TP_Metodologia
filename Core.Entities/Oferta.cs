using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Notas:
 * ID de oferta
 * Debe tener el usuario que hizo la oferta
 */


namespace Core.Entities
{
    [Table("Ofertas")]
    public class Oferta
    {
        [Key]
        public int OfertaID { get; set; }
        public int MontoOferta { get; set; }

        // Foreign Key a Usuario
        public int UsuarioID { get; set; }
        [ForeignKey("UsuarioID")]
        public virtual Usuario Usuario { get; set; }

        // Foreign Key a Subasta
        public int SubastaID { get; set; }
        [ForeignKey("SubastaID")]
        public virtual Subasta Subasta { get; set; }
    }
}
