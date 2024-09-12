using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppLibros.Migrations
{
    /// <inheritdoc />
    public partial class Calification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalificacionPromedio",
                table: "Libros");

            migrationBuilder.AddColumn<int>(
                name: "IdCalificacion",
                table: "Libros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Calificaciones",
                columns: table => new
                {
                    IdCalificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumCalificacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificaciones", x => x.IdCalificacion);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_IdCalificacion",
                table: "Libros",
                column: "IdCalificacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Calificaciones_IdCalificacion",
                table: "Libros",
                column: "IdCalificacion",
                principalTable: "Calificaciones",
                principalColumn: "IdCalificacion",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Calificaciones_IdCalificacion",
                table: "Libros");

            migrationBuilder.DropTable(
                name: "Calificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Libros_IdCalificacion",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "IdCalificacion",
                table: "Libros");

            migrationBuilder.AddColumn<double>(
                name: "CalificacionPromedio",
                table: "Libros",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
