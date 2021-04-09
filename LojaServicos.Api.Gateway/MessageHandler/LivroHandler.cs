using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

namespace LojaServicos.Api.Gateway.MessageHandler
{
    public class LivroHandler: DelegatingHandler
    {
        private readonly ILogger<LivroHandler> _logger;

        public LivroHandler(ILogger<LivroHandler> logger)
        {
            this._logger = logger;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var tempo = Stopwatch.StartNew();
            _logger.LogInformation("Inicia request");

            var response = base.SendAsync(request, cancellationToken);
            _logger.LogInformation($"esse processo levou {tempo.ElapsedMilliseconds}");
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
