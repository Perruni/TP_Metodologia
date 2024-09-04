﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Notas:
 * ID de subasta
 * Nombre
 * Tiene que tener una lista de productos
 */


namespace Core.Entities
{
    
    public class Categoria
    {
        public int categoriaID { get; set; }
        public string nombreCategoria { get; set; }

    }
}
