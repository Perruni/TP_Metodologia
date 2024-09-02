using Core.Configuration;
using Core.Data;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region CONNECTIONSTRING
//Connection String
var ConnectionString = builder.Configuration.GetConnectionString("Connection");

var connectionString = builder.Configuration.GetConnectionString("Connection");

/*var config = new Core.Configuration.Config()
{
    ConnectionString = connectionString
};

builder.Services.AddScoped<Config>(p =>
{
    return config;
});*/
builder.Services.AddDbContext<TPI_DbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


#endregion
//Registro de Conexion
builder.Services.AddDbContext<TPI_DbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

