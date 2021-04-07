using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LojaServicos.Api.CarrinhoCompras.Modelo;

using Microsoft.EntityFrameworkCore;

namespace LojaServicos.Api.CarrinhoCompras.Persistencia
{
    public class CarrinhoContexto: DbContext
    {
        public CarrinhoContexto(DbContextOptions<CarrinhoContexto> options): base(options) { }

        public DbSet<CarrinhoSessao> CarrinhosSessao { get; set; }
        public DbSet<CarrinhoSessaoDetalhe> CarrinhoSessaoDetalhes { get; set; }
    }
}
