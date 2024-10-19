using Core.Entities;

namespace Core.Shared.DTOs.Usuario
{
    public class UsuarioDTO
    {
        public int usuarioID { get; set; }
        public int DNI { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? direccion { get; set; }
        public int telefono { get; set; }
        public int codigoArea { get; set; }

        /*public Datos_usuarioDTO DatosUsuario { get; set; }*/
    }
}
