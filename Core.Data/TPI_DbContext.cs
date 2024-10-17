using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Data
{
    public class TPI_DbContext : DbContext
    {

        private readonly Config _config;

        public TPI_DbContext(DbContextOptions<TPI_DbContext> options, Config config)
            : base(options)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_config != null && !optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(_config.ConnectionString, ServerVersion.AutoDetect(_config.ConnectionString));
            }
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Subasta> Subastas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Datos_usuario> DatosUsuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.DatosUsuario)
                .WithOne(d => d.Usuario)
                .HasForeignKey<Datos_usuario>(d => d.usuarioID);

            base.OnModelCreating(modelBuilder);
        }

    }
}
