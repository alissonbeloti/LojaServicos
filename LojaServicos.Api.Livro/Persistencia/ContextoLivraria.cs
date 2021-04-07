using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LojaServicos.Api.Livro.Modelo;

using Microsoft.EntityFrameworkCore;

namespace LojaServicos.Api.Livro.Persistencia
{
    public class ContextoLivraria: DbContext
    {
        public ContextoLivraria() { }
        public ContextoLivraria(DbContextOptions<ContextoLivraria> options) : base(options) { }
        public virtual DbSet<LivrariaMaterial> LivrariaMateriais { get; set; }
    }
}
