using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Threading.Tasks;

using FluentValidation;

using LojaServicos.Api.Autor.Modelo;
using LojaServicos.Api.Autor.Persistencia;

using MediatR;

namespace LojaServicos.Api.Autor.Aplicacao
{
    public class Novo
    {
        public class Executa: IRequest
        {
            
            public string Nome { get; set; }
            
            public string Apelido { get; set; }
            public DateTime? Nascimento { get; set; }
        }
        public class ExecutaValidacao: AbstractValidator<Executa>
        {
            public ExecutaValidacao()
            {
                RuleFor(x => x.Nome).NotEmpty();
                RuleFor(x => x.Apelido).NotEmpty();
            }
        }
        public class Manipulador : IRequestHandler<Executa>
        {
            private readonly ContextoAutor _contexto;

            public Manipulador(ContextoAutor contexto)
            {
                this._contexto = contexto;
            }
            public async Task<Unit> Handle(Executa request, CancellationToken cancellationToken)
            {
                var autorLivro = new AutorLivro
                {
                    Nome = request.Nome,
                    Nascimento = request.Nascimento,
                    Apelido = request.Apelido,
                    AutorLivroGuid = Guid.NewGuid().ToString()
                };
                _contexto.AutoresLivros.Add(autorLivro);
                var valor = await _contexto.SaveChangesAsync();
                if (valor> 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Não foi possível inserir autor do livro");
            }
        }
    }
}
