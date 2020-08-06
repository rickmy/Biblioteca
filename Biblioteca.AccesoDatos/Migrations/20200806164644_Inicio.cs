using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.AccesoDatos.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bibliotecs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bibliotecs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lectores",
                columns: table => new
                {
                    LectorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimerNombre = table.Column<string>(nullable: true),
                    PrimerApellido = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    TipoLector = table.Column<string>(nullable: true),
                    Preferencias = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectores", x => x.LectorId);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Editorial = table.Column<string>(nullable: true),
                    Autor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bibliotecarios",
                columns: table => new
                {
                    BibliotecarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimerNombre = table.Column<string>(nullable: true),
                    PrimerApellido = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    BibliotecaId = table.Column<int>(nullable: false),
                    BibliotecasId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bibliotecarios", x => x.BibliotecarioId);
                    table.ForeignKey(
                        name: "FK_Bibliotecarios_Bibliotecs_BibliotecasId",
                        column: x => x.BibliotecasId,
                        principalTable: "Bibliotecs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: true),
                    LectorId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    BibliotecId = table.Column<int>(nullable: false),
                    BibliotecarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                    table.ForeignKey(
                        name: "FK_Prestamos_Bibliotecs_BibliotecId",
                        column: x => x.BibliotecId,
                        principalTable: "Bibliotecs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Bibliotecarios_BibliotecarioId",
                        column: x => x.BibliotecarioId,
                        principalTable: "Bibliotecarios",
                        principalColumn: "BibliotecarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Lectores_LectorId",
                        column: x => x.LectorId,
                        principalTable: "Lectores",
                        principalColumn: "LectorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallePrestamoLibro",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(nullable: false),
                    LibroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePrestamoLibro", x => new { x.LibroId, x.PrestamoId });
                    table.ForeignKey(
                        name: "FK_DetallePrestamoLibro_Libro_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallePrestamoLibro_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devoluciones",
                columns: table => new
                {
                    DevolucionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: true),
                    PrestamoId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    BibliotecId = table.Column<int>(nullable: false),
                    BibliotecarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devoluciones", x => x.DevolucionId);
                    table.ForeignKey(
                        name: "FK_Devoluciones_Bibliotecs_BibliotecId",
                        column: x => x.BibliotecId,
                        principalTable: "Bibliotecs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Devoluciones_Bibliotecarios_BibliotecarioId",
                        column: x => x.BibliotecarioId,
                        principalTable: "Bibliotecarios",
                        principalColumn: "BibliotecarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Devoluciones_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotecarios_BibliotecasId",
                table: "Bibliotecarios",
                column: "BibliotecasId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePrestamoLibro_PrestamoId",
                table: "DetallePrestamoLibro",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Devoluciones_BibliotecId",
                table: "Devoluciones",
                column: "BibliotecId");

            migrationBuilder.CreateIndex(
                name: "IX_Devoluciones_BibliotecarioId",
                table: "Devoluciones",
                column: "BibliotecarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Devoluciones_PrestamoId",
                table: "Devoluciones",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_BibliotecId",
                table: "Prestamos",
                column: "BibliotecId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_BibliotecarioId",
                table: "Prestamos",
                column: "BibliotecarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_LectorId",
                table: "Prestamos",
                column: "LectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallePrestamoLibro");

            migrationBuilder.DropTable(
                name: "Devoluciones");

            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Bibliotecarios");

            migrationBuilder.DropTable(
                name: "Lectores");

            migrationBuilder.DropTable(
                name: "Bibliotecs");
        }
    }
}
