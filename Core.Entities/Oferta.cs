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
        public int ofertaID { get; set; }
        public float montoOferta { get; set; }
        public EstadoOferta estadoOferta { get; set; }

        // Foreign Key a Usuario
        public int? usuarioID { get; set; }
        [ForeignKey("usuarioID")]
        public virtual Usuario? usuario { get; set; }

        // Foreign Key a Subasta
        public int? productoID { get; set; }
        [ForeignKey("productoID")]
        public virtual Producto? producto { get; set; }

        public enum EstadoOferta
        {
            Pendiente = 1,
            Ganadora = 2,
            NoGanadora =3
        }

    }
}
