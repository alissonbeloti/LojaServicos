using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaServicos.Api.Livro.Tests
{
    public class AsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> numerator;
        public T Current => numerator.Current;

        public AsyncEnumerator(IEnumerator<T> enumerator) => this.numerator = enumerator ?? throw new ArgumentNullException();
        
        public async ValueTask DisposeAsync()
        {
            await Task.CompletedTask;
        }

        public async ValueTask<bool> MoveNextAsync()
        {
            return await Task.FromResult(numerator.MoveNext());
        }
    }
}
