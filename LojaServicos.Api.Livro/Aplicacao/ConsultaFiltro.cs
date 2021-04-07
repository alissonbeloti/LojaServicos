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
    public class ConsultaFiltro
    {
        public class LivroUnico : IRequest<LivroMaterialDto>
        {
            public Guid? LivroId { get; set; }
        }
        public class Manipulador : IRequestHandler<LivroUnico, LivroMaterialDto>
        {
            private readonly ContextoLivraria _contexto;
            private readonly IMapper _mapper;

            public Manipulador(ContextoLivraria contexto, IMapper mapper)
            {
                this._contexto = contexto;
                this._mapper = mapper;
            }
            public async Task<LivroMaterialDto> Handle(LivroUnico request, CancellationToken cancellationToken)
            {
                var livro = await _contexto.LivrariaMateriais
                    .FirstOrDefaultAsync(l => l.LivraiaMaterialId == request.LivroId);
                if (livro != null)
                {
                    var livroDto = _mapper.Map<LivrariaMaterial, LivroMaterialDto>(livro);
                    return livroDto;
                }
                throw new Exception("O livro não foi encontrado!");
            }
        }
    }
}
