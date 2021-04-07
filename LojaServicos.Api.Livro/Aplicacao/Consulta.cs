using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using LojaServicos.Api.Livro.Aplicacao.Dtos;
using LojaServicos.Api.Livro.Modelo;
using LojaServicos.Api.Livro.Persistencia;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace LojaServicos.Api.Livro.Aplicacao
{
    public class Consulta
    {
        public class Executa: IRequest<List<LivroMaterialDto>> { }
        public class Manipulador : IRequestHandler<Executa, List<LivroMaterialDto>>
        {
            private readonly ContextoLivraria _contexto;
            private readonly IMapper _mapper;

            public Manipulador(ContextoLivraria contexto, IMapper mapper)
            {
                this._contexto = contexto;
                this._mapper = mapper;
            }
            public async Task<List<LivroMaterialDto>> Handle(Executa request, CancellationToken cancellationToken)
            {
                var livros = await _contexto.LivrariaMateriais.ToListAsync();
                var livrosDto = _mapper.Map<List<LivrariaMaterial>, List<LivroMaterialDto>>(livros);
                return livrosDto;
            }
        }
    }
}
