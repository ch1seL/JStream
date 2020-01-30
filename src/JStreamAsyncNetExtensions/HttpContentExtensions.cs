using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ch1seL.Newtonsoft.AsyncExtensions
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ToObjectAsync<T>(this HttpContent content, CancellationToken cancellationToken = default)
        {
            return await content
                .ReadAsStreamAsync()
                .ToObjectAsync<T>(cancellationToken: cancellationToken)
                .ConfigureAwait(false);
        }
    }
}