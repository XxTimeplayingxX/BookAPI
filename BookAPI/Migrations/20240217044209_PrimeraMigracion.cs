using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookAPI.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "libros",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publicacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libros", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LibroID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Generos_libros_LibroID",
                        column: x => x.LibroID,
                        principalTable: "libros",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    LibroID = table.Column<int>(type: "int", nullable: false),
                    FechaPedido = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_libros_LibroID",
                        column: x => x.LibroID,
                        principalTable: "libros",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneroDetalles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneroID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroDetalles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GeneroDetalles_Generos_GeneroID",
                        column: x => x.GeneroID,
                        principalTable: "Generos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ID", "NombreCompleto", "email" },
                values: new object[,]
                {
                    { 1, "Juan Pérez", "juan@gmail.com" },
                    { 2, "María García", "maria@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "libros",
                columns: new[] { "ID", "Autor", "Publicacion", "Titulo" },
                values: new object[,]
                {
                    { 1, "Dan Brown", new DateTime(2003, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "El código Da Vinci" },
                    { 2, "Gabriel García Márquez", new DateTime(1967, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cien años de soledad" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "ID", "Descripcion", "LibroID", "Name" },
                values: new object[,]
                {
                    { 1, "Libros de misterio y suspenso", 1, "Misterio" },
                    { 2, "Libros con elementos de fantasía en un contexto realista", 2, "Realismo mágico" }
                });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "ID", "ClienteID", "FechaPedido", "LibroID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 9, 23, 42, 9, 287, DateTimeKind.Local).AddTicks(1565), 1 },
                    { 2, 2, new DateTime(2024, 2, 2, 23, 42, 9, 287, DateTimeKind.Local).AddTicks(1577), 2 }
                });

            migrationBuilder.InsertData(
                table: "GeneroDetalles",
                columns: new[] { "ID", "GeneroID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneroDetalles_GeneroID",
                table: "GeneroDetalles",
                column: "GeneroID");

            migrationBuilder.CreateIndex(
                name: "IX_Generos_LibroID",
                table: "Generos",
                column: "LibroID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteID",
                table: "Pedidos",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_LibroID",
                table: "Pedidos",
                column: "LibroID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneroDetalles");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "libros");
        }
    }
}
