using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilSubastas.Models
{
    public class Usuario
    {
        public int usuarioID { get; set; }
        public string email { get; set; }
        public string contrasenia { get; set; }
        public List<Producto>? listaProductos { get; set; }
        public List<Oferta>? listaOfertas { get; set; }
        public Datos_usuario? DatosUsuario { get; set; }

    }
}
