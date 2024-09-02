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
        public bool estadoSubasta { get; set; }
        public int cantidadProduct { get; set; }

        // Foreign Key a Usuario (Creador de la subasta)
        public int usuarioCreadorID { get; set; }
        [ForeignKey("usuarioCreadorID")]
        public virtual Usuario Usuario { get; set; }

        // Foreign Key a Producto
        public int productoID { get; set; }
        [ForeignKey("productoID")]
        public virtual Producto Producto { get; set; }

    }
}


