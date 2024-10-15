using Core.Entities;

namespace Master_API.DTOs.SubastasDTO
{
    public class SubastaProductosDTO
    {
        public int subastaID { get; set; }
        public List<ProductoDTO> listaProductos { get; set; }


    }
}
