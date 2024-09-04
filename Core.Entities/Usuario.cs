using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Notas IMPORTANTE:
 * En roles el 1 es para ADMINISTRADORES y el 0 para usuarios COMUNES
 */


namespace Core.Entities
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int usuarioID { get; set; }
        public string nombreUsuario { get; set; }
        public string apellidoUsuario { get; set; }
        public int dni { get; set; }
        public string email { get; set; }
        public string domicilio { get; set; }
        public int roles { get; set; }

    }
}
