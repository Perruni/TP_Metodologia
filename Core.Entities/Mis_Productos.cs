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

   
    public class Mis_Productos
    {        
        public virtual ICollection<Producto> productosPendientes { get; set; } = new List<Producto>();
        public virtual ICollection<Producto> productosAprobadas { get; set; } = new List<Producto>();
        public virtual ICollection<Producto> productosRechazados { get; set; } = new List<Producto>();


    }
}
