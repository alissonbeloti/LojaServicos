using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using LojaServicos.Api.Autor.Modelo;

namespace LojaServicos.Api.Autor.Aplicacao
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<AutorLivro, AutorDto>();
        }
    }
}
