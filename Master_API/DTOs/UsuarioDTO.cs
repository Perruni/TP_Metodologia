using Core.Entities;

namespace Master_API.DTOs
{
    public class UsuarioDTO
    {
        public int UsuarioID { get; set; }
        public List<ProductoDTO> ListaProductos { get; set; }

        /*public Datos_usuarioDTO DatosUsuario { get; set; }*/
    }
}
