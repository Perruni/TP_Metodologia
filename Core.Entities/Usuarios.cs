using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Notas:
 * ID de usuario
 * Nombre
 * Apellido
 * DNI
 * Correo
 */


namespace Core.Entities
{
    internal class Usuarios
    {

        public int usuariosId { get; set; }
        public string nombreUsuario { get; set; }

        public string apellidoUsuario { get; set; }

        public int dni { get; set; }

        public string email { get; set; }.

    }
}
