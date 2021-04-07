using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace LojaServicos.Api.Autor.Modelo
{
    public class GrauAcademico
    {
        public int GrauAcademicoId { get; set; }
        public string Nome { get; set; }
        public string CentroAcademico { get; set; }
        public DateTime? DataGraduacao { get; set; }

        public int AutorLivroId { get; set; }
        public AutorLivro AutorLivro { get; set; }

        public string GrauAcademicoGuid { get; set; }
    }
}
