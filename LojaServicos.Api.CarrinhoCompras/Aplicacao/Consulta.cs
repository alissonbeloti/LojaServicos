using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using LojaServicos.Api.CarrinhoCompras.Aplicacao.Dto;
using LojaServicos.Api.CarrinhoCompras.Persistencia;
using LojaServicos.Api.CarrinhoCompras.RemoteInterface;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace LojaServicos.Api.CarrinhoCompras.Aplicacao
{
    public class Consulta
    {
        public class Executa : IRequest<CarrinhoDto>
        {
            public int CarrinhoSessaoId { get; set; }
        }

        public class Manipulador : IRequestHandler<Executa, CarrinhoDto>
        {
            private readonly CarrinhoContexto _contexto;
            private readonly ILivrosService _livrosService;

            public Manipulador(CarrinhoContexto contexto, ILivrosService livrosService)
            {
                this._contexto = contexto;
                this._livrosService = livrosService;
            }
            public async Task<CarrinhoDto> Handle(Executa request, CancellationToken cancellationToken)
            {
                var carrinhoSessao = await _contexto.CarrinhosSessao.FirstOrDefaultAsync(cs => cs.CarrinhoSessaoId == request.CarrinhoSessaoId);
                var carrinhoSessaoDetalhe = await _contexto.CarrinhoSessaoDetalhes.Where(csd => csd.CarrinhoSessaoId == request.CarrinhoSessaoId).ToArrayAsync();
                var listaCarrinhoDto = new List<CarrinhoDetalheDto>();
                foreach (var livro in carrinhoSessaoDetalhe)
                {
                    var response = await _livrosService.GetLivro(new Guid(livro.ProdutoSelecionado));
                    if (response.resultado)
                    {
                        var carrinhoDetalhe = new CarrinhoDetalheDto
                        {
                            TituloLivro = response.Livro.Titulo,
                            Publicacao = response.Livro.DataPublicacao,
                            LivroId = response.Livro.LivraiaMaterialId,
                        };
                        listaCarrinhoDto.Add(carrinhoDetalhe);
                    }
                }
                var carrinhoSessaoDto = new CarrinhoDto
                {
                    CarrinhoId = carrinhoSessao.CarrinhoSessaoId,
                    Criacao = carrinhoSessao.Criacao,
                    ListaProdutos = listaCarrinhoDto,
                };
                return carrinhoSessaoDto;
            }
        }
    }
}
