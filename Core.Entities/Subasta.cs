using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Notas:
 * ID de subasta
 * Titulo
 * Debe tener Fecha de inicio de la subasta y de finalización
 * Ofertas
 * Precio base
 * Ver como cargar imagenes(Importante)
 * Estado de la subasta
 * Descripción
 * Cantidad
 * 
 * Relación a través de la ID del usuario ya que estos crean las subastas
 */


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


