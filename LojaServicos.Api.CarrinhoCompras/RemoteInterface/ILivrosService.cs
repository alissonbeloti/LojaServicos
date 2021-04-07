using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LojaServicos.Api.CarrinhoCompras.RemoteModel;

namespace LojaServicos.Api.CarrinhoCompras.RemoteInterface
{
    public interface ILivrosService
    {
        Task<(bool resultado, LivroRemote Livro, string ErrorMessage)> GetLivro(Guid LivroId);
    }
}
