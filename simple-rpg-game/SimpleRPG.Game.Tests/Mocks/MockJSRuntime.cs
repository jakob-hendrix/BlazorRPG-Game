using Microsoft.JSInterop;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleRPG.Game.Tests.Mocks
{
    public class MockJSRuntime : IJSRuntime
    {
        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object[] args)
        {
            return new ValueTask<TValue>();
        }

        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object[] args)
        {
            return new ValueTask<TValue>();
        }
    }
}