using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServicos.Api.CarrinhoCompras.Aplicacao.Dto
{
    public class CarrinhoDto
    {
        public int CarrinhoId { get; set; }
        public DateTime? Criacao { get; set; }
        public List<CarrinhoDetalheDto> ListaProdutos { get; set; }
    }
}
