using Core.Busisness.Interfaces;
using Core.Busisness;
using Core.Configuration;
using Core.Data;
using Core.Data.Interface;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using BlobImagesTest.Services;
using Web_Subasta.Services;

var builder = WebApplication.CreateBuilder(args);

#region CONNECTIONSTRING
//Connection String
var ConnectionString = builder.Configuration.GetConnectionString("Connection");

var connectionString = builder.Configuration.GetConnectionString("Connection");

var config = new Core.Configuration.Config()
{
    ConnectionString = connectionString
};

builder.Services.AddScoped<Config>(p =>
{
    return config;
});

builder.Services.AddScoped<TPI_DbContext>(provider =>
{
    var config = provider.GetRequiredService<Config>();
    var optionsBuilder = new DbContextOptionsBuilder<TPI_DbContext>();
    optionsBuilder.UseMySql(config.ConnectionString, ServerVersion.AutoDetect(config.ConnectionString));
    return new TPI_DbContext(optionsBuilder.Options, config);
});
#endregion

//Registro de Conexion
builder.Services.AddDbContext<TPI_DbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Configuración de sesiones
builder.Services.AddDistributedMemoryCache();  // Usamos memoria para las sesiones
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".UsuarioSesion";  // Nombre de la cookie que contiene la sesión
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Tiempo de sesión
    options.Cookie.IsEssential = true;  // Marca la cookie como esencial para la aplicación
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IServiceAPI, ServiceAPI>();
builder.Services.AddScoped<IAzureBlobStorageService, AzureBlobStorageService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProductoBusiness, ProductoBusiness>();
builder.Services.AddScoped<IDatosUsuarioBusiness, DatosUsuarioBusiness>();
builder.Services.AddScoped<IUsuarioBussiness, UsuarioBusiness>();
builder.Services.AddScoped<IOfertaBussiness, OfertaBusiness>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole(); // Habilitar logging en la consola
builder.Logging.AddDebug();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Usar sesiones en la aplicación
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
