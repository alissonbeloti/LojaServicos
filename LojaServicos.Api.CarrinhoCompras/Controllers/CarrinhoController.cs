using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LojaServicos.Api.CarrinhoCompras.Aplicacao;
using LojaServicos.Api.CarrinhoCompras.Aplicacao.Dto;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaServicos.Api.CarrinhoCompras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly IMediator mediator;

        public CarrinhoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Criar(Novo.Executa dados)
        {
            return await this.mediator.Send(dados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarrinhoDto>> GetCarrinho(int id)
        {
            return await this.mediator.Send(new Consulta.Executa { CarrinhoSessaoId = id });
        }
    }
}
