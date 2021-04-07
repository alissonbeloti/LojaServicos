using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaServicos.Api.Livro.Migrations
{
    public partial class MigracaoSqlServerInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LivrariaMateriais",
                columns: table => new
                {
                    LivraiaMaterialId = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    DataPublicacao = table.Column<DateTime>(nullable: true),
                    AutorLivro = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivrariaMateriais", x => x.LivraiaMaterialId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivrariaMateriais");
        }
    }
}
