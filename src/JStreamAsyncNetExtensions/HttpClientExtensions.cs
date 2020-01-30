using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ch1seL.Newtonsoft.AsyncExtensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> GetJsonAsAsync<T>(this HttpClient client, string url,
            CancellationToken cancellationToken = default)
        {
            return await client.GetAsync(url, cancellationToken).ToObjectAsync<T>();
        }

        public static async Task<TResult> PostAsJsonWithResultAsync<T, TResult>(this HttpClient client, string url,
            T obj, CancellationToken cancellationToken = default)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8,
                MediaTypeNames.Application.Json);
            var responseMessage = await client.PostAsync(url, content, cancellationToken);
            responseMessage.EnsureSuccessStatusCode();
            return await responseMessage.Content.ReadAsStreamAsync()
                .ToObjectAsync<TResult>(cancellationToken: cancellationToken);
        }

        public static async Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, string url, T obj,
            CancellationToken cancellationToken = default)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8,
                MediaTypeNames.Application.Json);
            return await client.PostAsync(url, content, cancellationToken);
        }

        public static async Task<HttpResponseMessage> PutAsJsonAsync<T>(this HttpClient client, string url, T obj,
            CancellationToken cancellationToken = default)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8,
                MediaTypeNames.Application.Json);
            return await client.PutAsync(url, content, cancellationToken);
        }

        public static async Task<TResult> PutAsJsonWithResultAsync<T, TResult>(this HttpClient client, string url,
            T obj, CancellationToken cancellationToken = default)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8,
                MediaTypeNames.Application.Json);
            var responseMessage = await client.PutAsync(url, content, cancellationToken);
            responseMessage.EnsureSuccessStatusCode();
            return await responseMessage.Content.ReadAsStreamAsync()
                .ToObjectAsync<TResult>(cancellationToken: cancellationToken);
        }
    }
}