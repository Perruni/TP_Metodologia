using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    /*Nota:Se encarga de la verificacion de la subasta, si esta pendiente por aprobar,
     si ya fue aprobada o si es rechazada(opcional), esto a travez de un atributo de las subasta
    llamado controlSubasta(1 aprobado, 0 pendiente)

    *IMPORTANTE: estos es solo para escritorio y deberia poder filtrar por subasta con mayor oferta
    
    Deberia tener 3 listas:
    Pendientes
    Aprobadas
    Rechazadas(opcional)
     */

   
    public class Gestion_Subasta
    {        
        public int GestorID { get; set; }
        public virtual ICollection<Subasta> Subastas_Pendientes { get; set; } = new List<Subasta>();
        public virtual ICollection<Subasta> Subastas_Aprobadas { get; set; }= new List<Subasta>();
        
    }
}
