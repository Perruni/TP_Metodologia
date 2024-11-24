using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilSubastas.Models
{
    public class Datos_usuario
    {
        public int usuarioID { get; set; }

        public int DNI { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? direccion { get; set; }
        public string? telefono { get; set; }
        public int codigoArea { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
