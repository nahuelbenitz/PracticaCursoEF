using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiMinimalAPI;
using MiMinimalAPI.Models;

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

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContex) =>
{
	return Results.Ok(dbContex.Tareas.Include(p => p.Categoria).Where(p => p.PrioridadTarea == MiMinimalAPI.Models.Prioridad.Baja));
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContex, [FromBody] Tarea tarea) =>
{
	tarea.TareaId = Guid.NewGuid();
	tarea.FechaCreacion = DateTime.Now;
	await dbContex.AddAsync(tarea);

	await dbContex.SaveChangesAsync();
	return Results.Ok();
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContex, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
	var tareaActual = dbContex.Tareas.Find(id);

	if(tareaActual != null)
	{
		tareaActual.CategoriaId = tarea.CategoriaId;
		tareaActual.Titulo = tarea.Titulo;
		tareaActual.PrioridadTarea = tarea.PrioridadTarea;
		tareaActual.Descripcion = tarea.Descripcion;

		await dbContex.SaveChangesAsync();

		return Results.Ok();
	}

	return Results.NotFound();
});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContex, [FromRoute] Guid id) =>
{
	var tareaActual = dbContex.Tareas.Find(id);

	if (tareaActual != null)
	{
		dbContex.Remove(tareaActual);

		await dbContex.SaveChangesAsync();
		return Results.Ok();
	}

	return Results.NotFound();
});

app.Run();
