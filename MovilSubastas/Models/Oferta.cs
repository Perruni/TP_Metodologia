using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilSubastas.Models
{
    public class Oferta
    {
        public int ofertaID { get; set; }
        public float montoOferta { get; set; }
        public DateTime fechaOferta { get; set; }
        public EstadoOferta estadoOferta { get; set; }
        public virtual Producto? producto { get; set; }

        public enum EstadoOferta
        {
            Pendiente = 1,
            Ganadora = 2,
            NoGanadora = 3
        }

    }
}
