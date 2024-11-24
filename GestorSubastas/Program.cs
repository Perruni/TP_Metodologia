using Core.Busisness.Interfaces;
using Core.Busisness;
using Core.Data.Interface;
using Core.Data;
using Microsoft.Extensions.DependencyInjection;
using Core.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace GestorSubastas
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            var formInicio = serviceProvider.GetRequiredService<FormInicio>();
            Application.Run(formInicio);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            var connectionString = Properties.Settings.Default.Connection;

            var config = new Config()
            {
                ConnectionString = connectionString
            };

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            services.AddLogging(configure => configure.AddConsole())
                    .AddScoped<Config>(p =>
                    {
                        return config;
                    })
                    .AddScoped<IOfertaBussiness, OfertaBusiness>()
                    .AddScoped<IDatosUsuarioBusiness, DatosUsuarioBusiness>()
                    .AddScoped<IProductoBusiness, ProductoBusiness>()
                    .AddScoped<IUsuarioBussiness, UsuarioBusiness>()
                    .AddScoped<ISubastaBusiness, Subastasbusiness>()
                    .AddScoped<IProjectRepository, ProjectRepository>()
                    .AddScoped<FormInicio>()
                    .AddScoped<TPI_DbContext>(provider =>
            {
                var config = provider.GetRequiredService<Config>();
                var optionsBuilder = new DbContextOptionsBuilder<TPI_DbContext>();
                optionsBuilder.UseSqlServer(config.ConnectionString); // Cambiado a SQL Server
                return new TPI_DbContext(optionsBuilder.Options, config);
            });


        }



    }
}