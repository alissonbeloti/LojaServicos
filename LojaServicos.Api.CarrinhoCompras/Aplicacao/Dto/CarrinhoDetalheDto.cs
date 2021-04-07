using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServicos.Api.CarrinhoCompras.Aplicacao.Dto
{
    public class CarrinhoDetalheDto
    {
        public Guid? LivroId { get; set; }
        public string TituloLivro { get; set; }
        public string AutorLivro { get; set; }
        public DateTime? Publicacao { get; set; }
    }
}
