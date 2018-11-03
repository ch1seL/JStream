using System.Net.Http;
using System.Threading.Tasks;

namespace JStreamAsyncNet
{
	public static class HttpResponseMessageExtensions
	{
		public static async Task<T> ToObject<T>(this Task<HttpResponseMessage> response)
		{
			HttpResponseMessage result = await response;

			result.EnsureSuccessStatusCode();

			return await result.Content.ReadAsStreamAsync().ToObject<T>().ConfigureAwait(false);
		}

		public static async Task<T[]> ToArray<T>(this Task<HttpResponseMessage> response)
		{
			HttpResponseMessage result = await response;

			result.EnsureSuccessStatusCode();

			return await result.Content.ReadAsStreamAsync().ToArray<T>().ConfigureAwait(false);
		}
	}
}