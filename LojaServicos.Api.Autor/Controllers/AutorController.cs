using System.Collections.Generic;
using System.Threading.Tasks;

using LojaServicos.Api.Autor.Aplicacao;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace LojaServicos.Api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Criar(Novo.Executa dados)
        {
            return await _mediator.Send(dados);
        }

        [HttpGet]
        public async Task<List<AutorDto>> GetAutores()
        {
            return await _mediator.Send(new Consulta.ListaAutor());
        }

        [HttpGet("{guid}")]
        public async Task<AutorDto> GetAutor(string guid)
        {
            return await _mediator.Send(new ConsultaFiltro.AutorUnico { AutorGuid = guid });
        }
    }
}
