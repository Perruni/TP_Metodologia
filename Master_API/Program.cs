using Core.Busisness.Interfaces;
using Core.Busisness;
using Core.Configuration;
using Core.Data;
using Core.Data.Interface;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; // Permitir ciclos
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProductoBusiness, ProductoBusiness>();
builder.Services.AddScoped<IDatosUsuarioBusiness, DatosUsuarioBusiness>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

//loggin
builder.Logging.ClearProviders();
builder.Logging.AddConsole(); // Habilitar logging en la consola
builder.Logging.AddDebug();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

