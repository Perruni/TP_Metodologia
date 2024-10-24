using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Web_Subasta.Models.ViewModels
{
	public class DatosUsuarioVM 
	{

        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public int codigoArea { get; set; }
        public int usuarioID { get; set; }

        public Datos_usuario? datosUsuario { get; set; }
    }
}
