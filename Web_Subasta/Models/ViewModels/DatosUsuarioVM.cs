﻿using Microsoft.AspNetCore.Mvc;

namespace Web_Subasta.Models.ViewModels
{
	public class DatosUsuarioVM 
	{
		public string Nombre { get; set; }
		public string apellido {  get; set; }
		public int dni {  get; set; }
		public string Email { get; set; }
		public int CodeArea { get; set; }
		public string Telefono { get; set; }
		public string direccion {  get; set; }
	}
}
