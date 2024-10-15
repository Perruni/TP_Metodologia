using Core.Entities;

namespace Core.Shared
{
    public class UsuarioDTO
    {
        public int usuarioID { get; set; }
        public List<ProductoDTO> listaProductos { get; set; }

        /*public Datos_usuarioDTO DatosUsuario { get; set; }*/
    }
}
