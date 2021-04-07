using System;
using System.Collections.Generic;
using System.Text;

using AutoMapper;

using LojaServicos.Api.Livro.Aplicacao.Dtos;
using LojaServicos.Api.Livro.Modelo;

namespace LojaServicos.Api.Livro.Tests
{
    public class MappingTest: Profile
    {
        public MappingTest()
        {
            CreateMap<LivrariaMaterial, LivroMaterialDto>();
        }
    }
}
