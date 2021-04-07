using System;
using System.ComponentModel.DataAnnotations;

namespace LojaServicos.Api.Livro.Modelo
{
    public class LivrariaMaterial
    {
        [Key]
        public Guid? LivraiaMaterialId { get; set; }
        public string Titulo { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public Guid? AutorLivro { get; set; }
    }
}
