using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Notas:
 * La manera de mostrar el historial deberia ser a través de la ID de la oferta
 * (Subasta deberia tener la ID de oferta)
 */


namespace Core.Entities
{
    [Table("Historial")]
    public class Historial
    {
        [Key]
        public int HistorialID { get; set; }
        public virtual ICollection<Subasta> Subastas_Creadas { get; set; } = new List<Subasta>();

        public virtual ICollection<Subasta> Subastas_Ofertadas { get; set; } = new List<Subasta>();

        public virtual ICollection<Subasta> Subastas_General { get; set; } = new List<Subasta>();


    }
}
