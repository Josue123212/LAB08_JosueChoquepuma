using Microsoft.EntityFrameworkCore;
using LAB08_JosueChoquepuma.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger básico
builder.Services.AddSwaggerGen();

// 1. DbContext con PostgreSQL (LINQExample)
builder.Services.AddDbContext<LinqexampleContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection") 
                      ?? "Host=localhost;Database=LINQExample;Username=postgres;Password=javier.com123;"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "LAB08_JosueChoquepuma V1");
        c.RoutePrefix = string.Empty; // Carga Swagger directo al iniciar
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();