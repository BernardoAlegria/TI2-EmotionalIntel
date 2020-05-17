using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmotionalIntel.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Testes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    NRespostas = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    PontuacaoMedia = table.Column<int>(nullable: false),
                    PontuacaoAlta = table.Column<int>(nullable: false),
                    UtilizadorFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Testes_Utilizadores_UtilizadorFK",
                        column: x => x.UtilizadorFK,
                        principalTable: "Utilizadores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Perguntas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TxtPergunta = table.Column<string>(nullable: false),
                    TesteFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perguntas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Perguntas_Testes_TesteFK",
                        column: x => x.TesteFK,
                        principalTable: "Testes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tecnicas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Nivel = table.Column<string>(nullable: false),
                    TesteFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnicas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tecnicas_Testes_TesteFK",
                        column: x => x.TesteFK,
                        principalTable: "Testes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Testes_Realizados",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pontuacao = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    UtilizadorFK = table.Column<int>(nullable: true),
                    TesteFK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testes_Realizados", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Testes_Realizados_Testes_TesteFK",
                        column: x => x.TesteFK,
                        principalTable: "Testes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Testes_Realizados_Utilizadores_UtilizadorFK",
                        column: x => x.UtilizadorFK,
                        principalTable: "Utilizadores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Respostas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TxtRespostas = table.Column<string>(nullable: false),
                    PerguntaFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respostas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Respostas_Perguntas_PerguntaFK",
                        column: x => x.PerguntaFK,
                        principalTable: "Perguntas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_TesteFK",
                table: "Perguntas",
                column: "TesteFK");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_PerguntaFK",
                table: "Respostas",
                column: "PerguntaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Tecnicas_TesteFK",
                table: "Tecnicas",
                column: "TesteFK");

            migrationBuilder.CreateIndex(
                name: "IX_Testes_UtilizadorFK",
                table: "Testes",
                column: "UtilizadorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Testes_Realizados_TesteFK",
                table: "Testes_Realizados",
                column: "TesteFK");

            migrationBuilder.CreateIndex(
                name: "IX_Testes_Realizados_UtilizadorFK",
                table: "Testes_Realizados",
                column: "UtilizadorFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Respostas");

            migrationBuilder.DropTable(
                name: "Tecnicas");

            migrationBuilder.DropTable(
                name: "Testes_Realizados");

            migrationBuilder.DropTable(
                name: "Perguntas");

            migrationBuilder.DropTable(
                name: "Testes");

            migrationBuilder.DropTable(
                name: "Utilizadores");
        }
    }
}
