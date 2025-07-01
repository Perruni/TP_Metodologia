using Core.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public static class DbContextFactory
    {
        public static TPI_DbContext Create()
        {
            var config = new Config { ConnectionString = "server=localhost;database=tpi_metodologiadb;user=root;password=microkernel1;" };

            var options = new DbContextOptionsBuilder<TPI_DbContext>()
                .UseMySql(config.ConnectionString, ServerVersion.AutoDetect(config.ConnectionString))
                .Options;

            return new TPI_DbContext(options, config);
        }
    }
}
