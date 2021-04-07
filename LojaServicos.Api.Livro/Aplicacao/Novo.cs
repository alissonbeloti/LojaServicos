using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FluentValidation;

using LojaServicos.Api.Livro.Modelo;
using LojaServicos.Api.Livro.Persistencia;

using MediatR;

namespace LojaServicos.Api.Livro.Aplicacao
{
    public class Novo
    {
        public class Executa: IRequest
        {
            public string Titulo { get; set; }
            public DateTime? Publicacao { get; set; }
            public Guid? AutorLivro { get; set; }
        }

        public class ExecutaValicao: AbstractValidator<Executa>
        {
            public ExecutaValicao()
            {
                RuleFor(x => x.Titulo).NotEmpty();
                RuleFor(x => x.Publicacao).NotEmpty();
                RuleFor(x => x.AutorLivro).NotEmpty();
            }
        }

        public class Manipulador : IRequestHandler<Executa>
        {
            private readonly ContextoLivraria contexto;

            public Manipulador(ContextoLivraria contexto)
            {
                this.contexto = contexto;
            }
            public async Task<Unit> Handle(Executa request, CancellationToken cancellationToken)
            {
                var livro = new LivrariaMaterial
                {
                    Titulo = request.Titulo,
                    DataPublicacao = request.Publicacao,
                    AutorLivro = request.AutorLivro,
                };
                contexto.LivrariaMateriais.Add(livro);
                var qtd = await contexto.SaveChangesAsync();
                if (qtd > 0)
                    return Unit.Value;
                else
                    throw new Exception("Não foi possível salvar o livro.");
            }
        }
    }
}
