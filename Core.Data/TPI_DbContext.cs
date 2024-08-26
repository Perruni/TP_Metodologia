using Microsoft.EntityFrameworkCore;
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

        public TPI_DbContext(DbContextOptions<TPI_DbContext> options) : base(options) { }  

        public DbSet<Producto> Productos { get; set; }
        
    }
}
