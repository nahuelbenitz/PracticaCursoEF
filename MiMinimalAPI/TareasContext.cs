using Microsoft.EntityFrameworkCore;
using MiMinimalAPI.Models;

namespace MiMinimalAPI
{
	public class TareasContext : DbContext
	{
		public DbSet<Categoria> Categorias { get; set; }
		public DbSet<Tarea> Tareas { get; set; }

		public TareasContext(DbContextOptions<TareasContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			List<Categoria> categoriasInit = new List<Categoria>();

			categoriasInit.Add(new Categoria
			{
				CategoriaId = Guid.Parse("a5f81f00-de5d-45ed-be57-29d181d98cd7"),
				Nombre = "Actividades pendientes",
				Peso = 20
			});
			categoriasInit.Add(new Categoria
			{
				CategoriaId = Guid.Parse("a5f81f00-de5d-45ed-be57-29d181d98c02"),
				Nombre = "Actividades personales",
				Peso = 50
			});

			modelBuilder.Entity<Categoria>(categoria =>
			{
				categoria.ToTable("Categoria");
				categoria.HasKey(p => p.CategoriaId);

				categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);

				categoria.Property(p => p.Descipcion).IsRequired(false);
				categoria.Property(p => p.Peso);

				categoria.HasData(categoriasInit);
			});

			List<Tarea> tareasInit = new List<Tarea>();

			tareasInit.Add(new Tarea
			{
				TareaId = Guid.Parse("b4f81f00-de5d-45ed-be57-29d181d98cd7"),
				CategoriaId = Guid.Parse("a5f81f00-de5d-45ed-be57-29d181d98cd7"),
				PrioridadTarea = Prioridad.Media,
				Titulo = "Pagos de servicios publicos",
				FechaCreacion = DateTime.Now,
				FechaFinalizacion = DateTime.Now.AddDays(1),
			});

			tareasInit.Add(new Tarea
			{
				TareaId = Guid.Parse("b4f81f00-de5d-45ed-be57-29d181d98150"),
				CategoriaId = Guid.Parse("a5f81f00-de5d-45ed-be57-29d181d98c02"),
				PrioridadTarea = Prioridad.Baja,
				Titulo = "Terminar de ver pelicula en netflix",
				FechaCreacion = DateTime.Now,
				FechaFinalizacion = DateTime.Now.AddDays(1),
			});

			modelBuilder.Entity<Tarea>(tarea =>
			{
				tarea.ToTable("Tarea");
				tarea.HasKey(p => p.TareaId);
				tarea.HasOne(t => t.Categoria).WithMany(c => c.Tareas).HasForeignKey(t => t.CategoriaId);
				tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
				tarea.Property(p => p.Descripcion).IsRequired(false);
				tarea.Property(p => p.PrioridadTarea);
				tarea.Property(p => p.FechaCreacion);
				tarea.Property(p => p.FechaFinalizacion);
				tarea.Ignore(p => p.Resumen);

				tarea.HasData(tareasInit);
			});
		}
	}
}
