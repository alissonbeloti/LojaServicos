using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoMapper;

using GenFu;

using LojaServicos.Api.Livro.Aplicacao;
using LojaServicos.Api.Livro.Aplicacao.Dtos;
using LojaServicos.Api.Livro.Modelo;
using LojaServicos.Api.Livro.Persistencia;

using Microsoft.EntityFrameworkCore;

using Moq;

using Xunit;

namespace LojaServicos.Api.Livro.Tests
{
    public class LivroServiceTest
    {
        private IEnumerable<LivrariaMaterial> ObterDataProva()
        {
            A.Configure<LivrariaMaterial>()
                .Fill(x => x.Titulo)
                .AsArticleTitle()
                .Fill(x => x.LivraiaMaterialId, () => { return Guid.NewGuid(); });

            var lista = A.ListOf<LivrariaMaterial>(30);

            lista[0].LivraiaMaterialId = Guid.Empty;

            return lista;
        }

        private Mock<ContextoLivraria> CriarContexto()
        {
            var dataProva = ObterDataProva().AsQueryable();

            var dbSet = new Mock<DbSet<LivrariaMaterial>>();

            dbSet.As<IQueryable<LivrariaMaterial>>().Setup(x => x.Provider)
                .Returns(dataProva.Provider);

            dbSet.As<IQueryable<LivrariaMaterial>>().Setup(x => x.Expression)
                .Returns(dataProva.Expression);

            dbSet.As<IQueryable<LivrariaMaterial>>().Setup(x => x.ElementType)
                .Returns(dataProva.ElementType);

            dbSet.As<IQueryable<LivrariaMaterial>>().Setup(x => x.GetEnumerator())
                .Returns(dataProva.GetEnumerator());

            dbSet.As<IAsyncEnumerable<LivrariaMaterial>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                .Returns(new AsyncEnumerator<LivrariaMaterial>(dataProva.GetEnumerator()));

            var contexto = new Mock<ContextoLivraria>();
            contexto.Setup(x => x.LivrariaMateriais).Returns(dbSet.Object);
            return contexto;
        }
        [Fact]
        public async void GetLivros()
        {
            System.Diagnostics.Debugger.Launch();
            //Emular a instância da persistência (E) - contextLivraria

            //private readonly ContextoLivraria _contexto;
            //private readonly IMapper _mapper;

            var mockContexto = new Mock<ContextoLivraria>();

            //2- Emular o mapping 
            var mapperConfig = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingTest()); });

            var mapper = mapperConfig.CreateMapper();
            //3 - Instanciar o Manipulador.
            Consulta.Manipulador manipulador = new Consulta.Manipulador(mockContexto.Object, mapper);

            Consulta.Executa request = new Consulta.Executa();

            var lista = await manipulador.Handle(request, new System.Threading.CancellationToken());

            Assert.True(lista.Any());
        }
    }
}
