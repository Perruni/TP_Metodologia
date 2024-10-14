﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    

    public class Certificado
    {
        
        public int certificadoId { get; set; }
        public string metodoPago { get; set; }
        public DateTime fechaEmision { get; set; }


    }
}
