using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LojaServicos.Api.Autor.Migrations
{
    public partial class MigracaoPostgresInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoresLivros",
                columns: table => new
                {
                    AutorLivroId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    Apelido = table.Column<string>(nullable: true),
                    Nascimento = table.Column<DateTime>(nullable: true),
                    AutorLivroGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoresLivros", x => x.AutorLivroId);
                });

            migrationBuilder.CreateTable(
                name: "GrausAcademicos",
                columns: table => new
                {
                    GrauAcademicoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    CentroAcademico = table.Column<string>(nullable: true),
                    DataGraduacao = table.Column<DateTime>(nullable: true),
                    AutorLivroId = table.Column<int>(nullable: false),
                    GrauAcademicoGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrausAcademicos", x => x.GrauAcademicoId);
                    table.ForeignKey(
                        name: "FK_GrausAcademicos_AutoresLivros_AutorLivroId",
                        column: x => x.AutorLivroId,
                        principalTable: "AutoresLivros",
                        principalColumn: "AutorLivroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrausAcademicos_AutorLivroId",
                table: "GrausAcademicos",
                column: "AutorLivroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrausAcademicos");

            migrationBuilder.DropTable(
                name: "AutoresLivros");
        }
    }
}
