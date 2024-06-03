using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMOficialGestorDeTareasMVC.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DMCategoria",
                columns: table => new
                {
                    DMCategoriaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DMNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DMDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMCategoria", x => x.DMCategoriaID);
                });

            migrationBuilder.CreateTable(
                name: "DMPrioridad",
                columns: table => new
                {
                    DMPrioridadID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DMNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DMDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMPrioridad", x => x.DMPrioridadID);
                });

            migrationBuilder.CreateTable(
                name: "DMTarea",
                columns: table => new
                {
                    DMTareaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DMTitulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DMDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DMFechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DMPrioridadID = table.Column<int>(type: "int", nullable: false),
                    DMCategoriaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMTarea", x => x.DMTareaID);
                    table.ForeignKey(
                        name: "FK_DMTarea_DMCategoria_DMCategoriaID",
                        column: x => x.DMCategoriaID,
                        principalTable: "DMCategoria",
                        principalColumn: "DMCategoriaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DMTarea_DMPrioridad_DMPrioridadID",
                        column: x => x.DMPrioridadID,
                        principalTable: "DMPrioridad",
                        principalColumn: "DMPrioridadID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DMTarea_DMCategoriaID",
                table: "DMTarea",
                column: "DMCategoriaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DMTarea_DMPrioridadID",
                table: "DMTarea",
                column: "DMPrioridadID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMTarea");

            migrationBuilder.DropTable(
                name: "DMCategoria");

            migrationBuilder.DropTable(
                name: "DMPrioridad");
        }
    }
}
