using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    IdJugador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.IdJugador);
                });

            migrationBuilder.CreateTable(
                name: "Temas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTema = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    IdPartida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdJugador = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaActual = table.Column<int>(type: "int", nullable: false),
                    Conocimiento = table.Column<int>(type: "int", nullable: false),
                    Energia = table.Column<int>(type: "int", nullable: false),
                    Estres = table.Column<int>(type: "int", nullable: false),
                    Relaciones = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.IdPartida);
                    table.ForeignKey(
                        name: "FK_Partidas_Jugadores_IdJugador",
                        column: x => x.IdJugador,
                        principalTable: "Jugadores",
                        principalColumn: "IdJugador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreLogro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IdTema = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logros_Temas_IdTema",
                        column: x => x.IdTema,
                        principalTable: "Temas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Preguntas",
                columns: table => new
                {
                    IdPregunta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTema = table.Column<int>(type: "int", nullable: false),
                    PreguntaTexto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpcionA = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OpcionB = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OpcionC = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OpcionD = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Correcta = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Puntos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preguntas", x => x.IdPregunta);
                    table.ForeignKey(
                        name: "FK_Preguntas_Temas_IdTema",
                        column: x => x.IdTema,
                        principalTable: "Temas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogrosPartidas",
                columns: table => new
                {
                    IdLogroPartida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPartida = table.Column<int>(type: "int", nullable: false),
                    IdLogro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogrosPartidas", x => x.IdLogroPartida);
                    table.ForeignKey(
                        name: "FK_LogrosPartidas_Logros_IdLogro",
                        column: x => x.IdLogro,
                        principalTable: "Logros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogrosPartidas_Partidas_IdPartida",
                        column: x => x.IdPartida,
                        principalTable: "Partidas",
                        principalColumn: "IdPartida",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logros_IdTema",
                table: "Logros",
                column: "IdTema");

            migrationBuilder.CreateIndex(
                name: "IX_LogrosPartidas_IdLogro",
                table: "LogrosPartidas",
                column: "IdLogro");

            migrationBuilder.CreateIndex(
                name: "IX_LogrosPartidas_IdPartida",
                table: "LogrosPartidas",
                column: "IdPartida");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_IdJugador",
                table: "Partidas",
                column: "IdJugador");

            migrationBuilder.CreateIndex(
                name: "IX_Preguntas_IdTema",
                table: "Preguntas",
                column: "IdTema");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogrosPartidas");

            migrationBuilder.DropTable(
                name: "Preguntas");

            migrationBuilder.DropTable(
                name: "Logros");

            migrationBuilder.DropTable(
                name: "Partidas");

            migrationBuilder.DropTable(
                name: "Temas");

            migrationBuilder.DropTable(
                name: "Jugadores");
        }
    }
}
