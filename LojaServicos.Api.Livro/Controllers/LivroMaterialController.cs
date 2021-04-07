using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LojaServicos.Api.Livro.Aplicacao;
using LojaServicos.Api.Livro.Aplicacao.Dtos;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaServicos.Api.Livro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroMaterialController : ControllerBase
    {
        private readonly IMediator mediator;

        public LivroMaterialController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Criar(Novo.Executa dados)
        {
            return await mediator.Send(dados);
        }
        [HttpGet]
        public async Task<List<LivroMaterialDto>> GetLivros()
        {
            return await mediator.Send(new Consulta.Executa());
        }
        [HttpGet("{id}")]
        public async Task<LivroMaterialDto> GetLivro(Guid id)
        {
            var livro = new ConsultaFiltro.LivroUnico() { LivroId = id };
            return await mediator.Send(livro);
        }
    }
}
