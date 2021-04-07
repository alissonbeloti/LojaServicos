using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServicos.Api.Livro.Aplicacao.Dtos
{
    public class LivroMaterialDto
    {
        public Guid? LivraiaMaterialId { get; set; }
        public string Titulo { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public Guid? AutorLivro { get; set; }
    }
}
