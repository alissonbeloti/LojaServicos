using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServicos.Api.CarrinhoCompras.Modelo
{
    public class CarrinhoSessaoDetalhe
    {
        public int Id { get; set; }
        public DateTime? Criacao { get; set; }
        public int CarrinhoSessaoId { get; set; }
        public CarrinhoSessao CarrinhoSessao { get; set; }
        public string ProdutoSelecionado { get; set; }
    }
}
