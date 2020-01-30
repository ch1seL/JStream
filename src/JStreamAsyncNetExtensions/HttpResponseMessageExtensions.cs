using System.Net.Http;
using System.Threading.Tasks;

namespace Newtonsoft.Json.JStreamAsyncNetExtensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<T> ToObjectAsync<T>(this Task<HttpResponseMessage> response)
        {
            var result = await response.ConfigureAwait(false);

            result.EnsureSuccessStatusCode();

            return await result.Content.ReadAsStreamAsync().ToObjectAsync<T>().ConfigureAwait(false);
        }

        public static async Task<T[]> ToArrayAsync<T>(this Task<HttpResponseMessage> response)
        {
            var result = await response.ConfigureAwait(false);

            result.EnsureSuccessStatusCode();

            return await result.Content.ReadAsStreamAsync().ToArrayAsync<T>().ConfigureAwait(false);
        }
    }
}