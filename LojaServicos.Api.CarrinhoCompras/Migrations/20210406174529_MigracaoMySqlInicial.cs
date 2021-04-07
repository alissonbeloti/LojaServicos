using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace LojaServicos.Api.CarrinhoCompras.Migrations
{
    public partial class MigracaoMySqlInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarrinhosSessao",
                columns: table => new
                {
                    CarrinhoSessaoId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Criacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhosSessao", x => x.CarrinhoSessaoId);
                });

            migrationBuilder.CreateTable(
                name: "CarrinhoSessaoDetalhes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Criacao = table.Column<DateTime>(nullable: true),
                    CarrinhoSessaoId = table.Column<int>(nullable: false),
                    ProdutoSelecionado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoSessaoDetalhes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrinhoSessaoDetalhes_CarrinhosSessao_CarrinhoSessaoId",
                        column: x => x.CarrinhoSessaoId,
                        principalTable: "CarrinhosSessao",
                        principalColumn: "CarrinhoSessaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoSessaoDetalhes_CarrinhoSessaoId",
                table: "CarrinhoSessaoDetalhes",
                column: "CarrinhoSessaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoSessaoDetalhes");

            migrationBuilder.DropTable(
                name: "CarrinhosSessao");
        }
    }
}
