using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Core.Entities
{
    [Table("Subastas")]
    public class Subasta
    {
        [Key]
        public int subastaID { get; set; }
        public string titulo { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinalizado { get; set; }
        public EstadoSubasta estadoSubasta { get; set; }
        public MetodosdePago metodosdePago { get; set; }

        public List<Producto>? listaProductos { get; set; }

        public enum EstadoSubasta
        {
            Proxima = 1,
            Activa = 2,
            Finalizadas = 3,
            Deshabilitado = 4,

        }

        public enum MetodosdePago
        {
            Tarjetas = 1,
            Transferencia = 2,
            Ambos = 3,
        }


    }
}


