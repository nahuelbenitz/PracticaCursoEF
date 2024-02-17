using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiMinimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class ColumnFechaFinalizacionTarea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFinalizacion",
                table: "Tarea",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaFinalizacion",
                table: "Tarea");
        }
    }
}
