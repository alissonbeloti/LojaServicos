﻿
using AutoMapper;

using LojaServicos.Api.Livro.Aplicacao.Dtos;
using LojaServicos.Api.Livro.Modelo;

namespace LojaServicos.Api.Livro.Aplicacao
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<LivrariaMaterial, LivroMaterialDto>();
        }
    }
}
