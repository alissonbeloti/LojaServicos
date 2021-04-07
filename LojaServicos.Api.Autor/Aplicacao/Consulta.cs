using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using LojaServicos.Api.Autor.Modelo;
using LojaServicos.Api.Autor.Persistencia;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace LojaServicos.Api.Autor.Aplicacao
{
    public class Consulta
    {

        public class ListaAutor : IRequest<List<AutorDto>>
        { }
        public class Manipulador : IRequestHandler<ListaAutor, List<AutorDto>>
        {
            private readonly ContextoAutor _contexto;
            private readonly IMapper _mapper;

            public Manipulador(ContextoAutor contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<List<AutorDto>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var autores = await _contexto.AutoresLivros.ToListAsync();
                var autoresDto = _mapper.Map<List<AutorLivro>, List<AutorDto>>(autores);
                return autoresDto;
            }
        }
    }
}
