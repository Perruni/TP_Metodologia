﻿using Core.Entities;

namespace Web_Subasta.Models.ViewModels
{
    public class SubastaVM
    {
        public Subasta? _subasta { get; set; }

        public List<Producto>? productoLista { get; set; }

        public Producto? _producto { get; set; }

        public int subastaID { get; set; }
        public string titulo { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinalizado { get; set; }
        public int estadoSubasta { get; set; }
        public int metodosdePago { get; set; }

        public List<Producto>? listaProductos { get; set; }

    }
}
