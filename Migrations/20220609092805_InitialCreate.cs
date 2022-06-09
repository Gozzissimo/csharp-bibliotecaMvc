using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharp_bibliotecaMvc.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autore",
                columns: table => new
                {
                    AutoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascita = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autore", x => x.AutoreId);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    LibroId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Titolo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scaffale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stato = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.LibroId);
                });

            migrationBuilder.CreateTable(
                name: "Utente",
                columns: table => new
                {
                    UtenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utente", x => x.UtenteId);
                });

            migrationBuilder.CreateTable(
                name: "AutoreLibro",
                columns: table => new
                {
                    AutoriAutoreId = table.Column<int>(type: "int", nullable: false),
                    LibriLibroId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoreLibro", x => new { x.AutoriAutoreId, x.LibriLibroId });
                    table.ForeignKey(
                        name: "FK_AutoreLibro_Autore_AutoriAutoreId",
                        column: x => x.AutoriAutoreId,
                        principalTable: "Autore",
                        principalColumn: "AutoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoreLibro_Libro_LibriLibroId",
                        column: x => x.LibriLibroId,
                        principalTable: "Libro",
                        principalColumn: "LibroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestito",
                columns: table => new
                {
                    PrestitoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtenteId = table.Column<int>(type: "int", nullable: false),
                    LibroId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Inizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fine = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestito", x => x.PrestitoId);
                    table.ForeignKey(
                        name: "FK_Prestito_Libro_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libro",
                        principalColumn: "LibroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestito_Utente_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "Utente",
                        principalColumn: "UtenteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoreLibro_LibriLibroId",
                table: "AutoreLibro",
                column: "LibriLibroId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestito_LibroId",
                table: "Prestito",
                column: "LibroId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestito_UtenteId",
                table: "Prestito",
                column: "UtenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoreLibro");

            migrationBuilder.DropTable(
                name: "Prestito");

            migrationBuilder.DropTable(
                name: "Autore");

            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Utente");
        }
    }
}
