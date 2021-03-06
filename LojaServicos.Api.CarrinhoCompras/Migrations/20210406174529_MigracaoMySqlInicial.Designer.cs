// <auto-generated />
using System;
using LojaServicos.Api.CarrinhoCompras.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LojaServicos.Api.CarrinhoCompras.Migrations
{
    [DbContext(typeof(CarrinhoContexto))]
    [Migration("20210406174529_MigracaoMySqlInicial")]
    partial class MigracaoMySqlInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LojaServicos.Api.CarrinhoCompras.Modelo.CarrinhoSessao", b =>
                {
                    b.Property<int>("CarrinhoSessaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("Criacao")
                        .HasColumnType("datetime");

                    b.HasKey("CarrinhoSessaoId");

                    b.ToTable("CarrinhosSessao");
                });

            modelBuilder.Entity("LojaServicos.Api.CarrinhoCompras.Modelo.CarrinhoSessaoDetalhe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CarrinhoSessaoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Criacao")
                        .HasColumnType("datetime");

                    b.Property<string>("ProdutoSelecionado")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoSessaoId");

                    b.ToTable("CarrinhoSessaoDetalhes");
                });

            modelBuilder.Entity("LojaServicos.Api.CarrinhoCompras.Modelo.CarrinhoSessaoDetalhe", b =>
                {
                    b.HasOne("LojaServicos.Api.CarrinhoCompras.Modelo.CarrinhoSessao", "CarrinhoSessao")
                        .WithMany("ListaDetalhe")
                        .HasForeignKey("CarrinhoSessaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
