using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using LojaServicos.Api.Autor.Modelo;
using LojaServicos.Api.Autor.Persistencia;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace LojaServicos.Api.Autor.Aplicacao
{
    public class ConsultaFiltro
    {
        public class AutorUnico : IRequest<AutorDto>
        {
            public string AutorGuid { get; set; }
        }

        public class Manipulador : IRequestHandler<AutorUnico, AutorDto>
        {
            private readonly ContextoAutor contexto;
            private readonly IMapper mapper;

            public Manipulador(ContextoAutor contexto, IMapper mapper
                )
            {
                this.contexto = contexto;
                this.mapper = mapper;
            }
            public async Task<AutorDto> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await contexto.AutoresLivros.FirstOrDefaultAsync(x => x.AutorLivroGuid == request.AutorGuid);
                if (autor == null)
                {
                    throw new Exception("O autor não foi encontrado!");
                }
                var autorDto = this.mapper.Map<AutorLivro, AutorDto>(autor);
                return autorDto;
            }
        }
    }
}
