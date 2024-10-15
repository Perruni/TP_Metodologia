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
        public string email { get; set; }
        public string contrasenia {  get; set; }
        public List<Producto> listaProductos { get; set; }
        public List<Oferta> listaOfertas{ get; set; }

        public Datos_usuario DatosUsuario { get; set; }

    }
}
