﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Configuration;

namespace Core.Data
{
    public class TPI_DbContext : DbContext
    {


        private readonly Config _config;
        public TPI_DbContext(Config config)
        {
            _config = config;
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categoriaa { get; set; }
        public DbSet<Gestion_Subasta> Gestion_Subastas { get; set; }
        public DbSet<Historial> Historiales { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Subasta> Subastas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
