using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiMinimalAPI;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContex) =>
{
	dbContex.Database.EnsureCreated();
	return Results.Ok("Base de datos sql: " + dbContex.Database.IsInMemory());
});

app.Run();
