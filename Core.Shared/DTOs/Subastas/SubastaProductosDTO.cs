using Core.Entities;

namespace Core.Shared.DTOs.Subastas
{
    public class SubastaProductosDTO
    {
        public int subastaID { get; set; }
        public List<Producto.ProductoDTO> listaProductos { get; set; }


    }
}
