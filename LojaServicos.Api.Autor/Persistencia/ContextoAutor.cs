using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LojaServicos.Api.Autor.Modelo;

using Microsoft.EntityFrameworkCore;

namespace LojaServicos.Api.Autor.Persistencia
{
    public class ContextoAutor: DbContext
    {
        public ContextoAutor(DbContextOptions<ContextoAutor> options)
            : base (options)
        {

        }

        public DbSet<AutorLivro> AutoresLivros { get; set; }
        public DbSet<GrauAcademico> GrausAcademicos { get; set; }
    }
}
