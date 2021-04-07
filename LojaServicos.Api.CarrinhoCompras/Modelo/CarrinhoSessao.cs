using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServicos.Api.CarrinhoCompras.Modelo
{
    public class CarrinhoSessao
    {
        public int CarrinhoSessaoId { get; set; }
        public DateTime? Criacao { get; set; }

        public ICollection<CarrinhoSessaoDetalhe> ListaDetalhe { get; set; }
    }
}
