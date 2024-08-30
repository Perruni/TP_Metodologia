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
    /*Nota: Esto se encarga de aceptar o no los productos a rematar en las subastas
    
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
