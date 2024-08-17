﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Notas:
 * La manera de mostrar el historial deberia ser a través de la ID de la oferta
 * (Subasta deberia tener la ID de oferta)
 */


namespace Core.Entities
{
    internal class Historial
    {

        public virtual ICollection<Subastas> Subastas_Creadas { get; set; } = new List<Subastas>();

        public virtual ICollection<Subastas> Subastas_Ofertadas { get; set; } = new List<Subastas>();

        public virtual ICollection<Subastas> Subastas_General { get; set; } = new List<Subastas>();


    }
}
