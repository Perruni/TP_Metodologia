﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Notas:
 * La manera de mostrar el historial deberia ser a través de la ID de la oferta
 * (Subasta deberia tener la ID de oferta)
 * Las subastas rematando es para cuando los usuraios rematan un producto en cierta subasta
 */


namespace Core.Entities
{
    [Table("Historial")]
    public class Historial
    {
        [Key]
        public int HistorialID { get; set; }

        // Relación uno a muchos con Subastas
        public virtual ICollection<Subasta> Subastas_Rematando { get; set; } = new List<Subasta>();
        public virtual ICollection<Subasta> Subastas_Ofertadas { get; set; } = new List<Subasta>();
        public virtual ICollection<Subasta> Subastas_General { get; set; } = new List<Subasta>();
    }
}
