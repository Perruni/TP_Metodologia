using Core.Configuration;
using Core.Data;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

#region CONNECTIONSTRING
//Connection String
var ConnectionString = builder.Configuration.GetConnectionString("Connection");

var connectionString = builder.Configuration.GetConnectionString("connection");

var config = new Core.Configuration.Config()
{
    ConnectionString = connectionString
};

builder.Services.AddScoped<Config>(p =>
{
    return config;
});

#endregion
//Registro de Conexion
builder.Services.AddDbContext<TPI_DbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
