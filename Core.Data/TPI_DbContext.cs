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

        public TPI_DbContext(DbContextOptions<TPI_DbContext> options)
       : base(options)
        {
        }

        /*private readonly Config _config;

        public TPI_DbContext(Config config)
        {
            _config = config;
        }*/

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Subasta> Subastas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Certificado> Certificado { get; set; }
        public DbSet<Datos_ofertante> DatosOfertante { get; set; }
        public DbSet<Datos_vendedor> DatosVendedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Datos_ofertante>()
                .HasKey(d => new { d.DNI, d.oferID }); 

            modelBuilder.Entity<Datos_ofertante>()
                .HasOne(d => d.Oferta)
                .WithMany()
                .HasForeignKey(d => d.oferID);

            modelBuilder.Entity<Datos_vendedor>()
                .HasKey(d => new { d.DNI, d.producID });

            modelBuilder.Entity<Datos_vendedor>()
                .HasOne(d => d.Producto)
                .WithMany()
                .HasForeignKey(d => d.producID);


        }

        
    }
}
