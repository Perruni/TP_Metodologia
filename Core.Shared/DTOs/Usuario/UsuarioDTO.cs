using Core.Entities;

namespace Core.Shared.DTOs.Usuario
{
    public class UsuarioDTO
    {
        public int usuarioID { get; set; }
        public List<Producto.ProductoDTO> listaProductos { get; set; }

        /*public Datos_usuarioDTO DatosUsuario { get; set; }*/
    }
}
