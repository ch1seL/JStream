using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ch1seL.Newtonsoft.AsyncExtensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<T> ToObjectAsync<T>(this Task<HttpResponseMessage> response, CancellationToken cancellationToken = default)
        {
            var result = await response.ConfigureAwait(false);

            result.EnsureSuccessStatusCode();

            return await result.Content.ReadAsStreamAsync().ToObjectAsync<T>(cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}