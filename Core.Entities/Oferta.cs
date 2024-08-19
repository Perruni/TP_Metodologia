using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Notas:
 * ID de oferta
 * Debe tener el usuario que hizo la oferta
 */


namespace Core.Entities
{
    internal class Oferta
    {
        [Key]
        public int OfertaID { get; set; }
        public int user_ID { get; set; }
        public int MontoOferta { get; set; }

    }
}
