using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiMinimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descipcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descipcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("a5f81f00-de5d-45ed-be57-29d181d98c02"), null, "Actividades personales", 50 },
                    { new Guid("a5f81f00-de5d-45ed-be57-29d181d98cd7"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "FechaFinalizacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("b4f81f00-de5d-45ed-be57-29d181d98150"), new Guid("a5f81f00-de5d-45ed-be57-29d181d98c02"), null, new DateTime(2024, 2, 16, 22, 53, 4, 500, DateTimeKind.Local).AddTicks(5594), new DateTime(2024, 2, 17, 22, 53, 4, 500, DateTimeKind.Local).AddTicks(5594), 0, "Terminar de ver pelicula en netflix" },
                    { new Guid("b4f81f00-de5d-45ed-be57-29d181d98cd7"), new Guid("a5f81f00-de5d-45ed-be57-29d181d98cd7"), null, new DateTime(2024, 2, 16, 22, 53, 4, 500, DateTimeKind.Local).AddTicks(5570), new DateTime(2024, 2, 17, 22, 53, 4, 500, DateTimeKind.Local).AddTicks(5583), 1, "Pagos de servicios publicos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("b4f81f00-de5d-45ed-be57-29d181d98150"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("b4f81f00-de5d-45ed-be57-29d181d98cd7"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("a5f81f00-de5d-45ed-be57-29d181d98c02"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("a5f81f00-de5d-45ed-be57-29d181d98cd7"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descipcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
