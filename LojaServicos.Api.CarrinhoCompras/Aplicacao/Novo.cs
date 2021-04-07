using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using LojaServicos.Api.CarrinhoCompras.Modelo;
using LojaServicos.Api.CarrinhoCompras.Persistencia;

using MediatR;

namespace LojaServicos.Api.CarrinhoCompras.Aplicacao
{
    public class Novo
    {
        public class Executa: IRequest {
            public DateTime CriacaoSession { get; set; }
            public List<string> ProdutoLista { get; set; }
        }
        public class Manipulador : IRequestHandler<Executa>
        {
            private readonly CarrinhoContexto _contexto;


            public Manipulador(CarrinhoContexto contexto)
            {
                this._contexto = contexto;
            }
            public async Task<Unit> Handle(Executa request, CancellationToken cancellationToken)
            {
                var carrinho = new CarrinhoSessao
                {
                    Criacao = request.CriacaoSession,
                };

                _contexto.CarrinhosSessao.Add(carrinho);
                var x = await _contexto.SaveChangesAsync();
                if (x == 0)
                {
                    throw new Exception("Não foi possível iniciar carrinho.");
                }

                foreach (var item in request.ProdutoLista)
                {
                    var detalheSession = new CarrinhoSessaoDetalhe
                    {
                        CarrinhoSessaoId = carrinho.CarrinhoSessaoId,
                        Criacao = DateTime.Now,
                        ProdutoSelecionado = item
                    };

                    _contexto.CarrinhoSessaoDetalhes.Add(detalheSession);
                }
                x = await _contexto.SaveChangesAsync();

                if (x > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Não foi possível inserir no carrinho");
            }
        }
    }
}
