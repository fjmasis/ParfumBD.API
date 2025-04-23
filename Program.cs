using Microsoft.EntityFrameworkCore;
using ParfumBD.API;
using ParfumBD.API.Data;
using ParfumBD.API.Models;
using ParfumBD.API.Repositories;
using ParfumBD.API.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.ConfigureSwagger();

// Add database context
builder.Services.AddDbContext<ParfumBDContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPerfumeRepository, PerfumeRepository>();
// Make sure these are registered
builder.Services.AddScoped<IGenericRepository<Carrito>, GenericRepository<Carrito>>();
builder.Services.AddScoped<IGenericRepository<DetalleCarrito>, GenericRepository<DetalleCarrito>>();
// Add other repositories as needed

// Add services
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPerfumeService, PerfumeService>();
// Add other services as needed

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
