using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using LojaServicos.Api.CarrinhoCompras.RemoteInterface;
using LojaServicos.Api.CarrinhoCompras.RemoteModel;

using Microsoft.Extensions.Logging;

namespace LojaServicos.Api.CarrinhoCompras.RemoteServices
{
    public class LivrosService : ILivrosService
    {
        private readonly IHttpClientFactory httpClient;
        private readonly ILogger logger;

        public LivrosService(IHttpClientFactory httpClient, ILogger<LivrosService> logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }
        public async Task<(bool resultado, LivroRemote Livro, string ErrorMessage)> GetLivro(Guid LivroId)
        {
            try
            {
                var cliente = this.httpClient.CreateClient("Livros");
                var response = await cliente.GetAsync($"api/LivroMaterial/{LivroId}");

                if (response.IsSuccessStatusCode)
                {
                    var conteudo = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    var resultado = JsonSerializer.Deserialize<LivroRemote>(conteudo, options);
                    return (true, resultado, null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
