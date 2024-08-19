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
    internal class Subastas
    {
        [Key]
        public int SubastaID {  get; set; }
        public string titulo { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinalizado { get; set; }
        public int ofertas { get; set; }
        public double precioBase { get; set; }
        public bool estadoSubasta { get; set; }
        public string descripcion {  get; set; }
        public int cantidadProduct {  get; set; }
        public int usuario_creador { get; set; }
        public int productoID { get; set; }

        /*[ForeignKey]
        public int oferta_ID { get; set; }*/

    }
}


