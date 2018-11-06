using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JStreamAsyncNet
{
	public static class FileStreamExtensions
	{
		public static Task<T> ToObject<T>(this FileStream fileStream, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			return ((Stream) fileStream).ToObject<T>(serializer, cancellationToken);
		}

		public static Task<T[]> ToArray<T>(this FileStream fileStream, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			return ((Stream) fileStream).ToArray<T>(serializer, cancellationToken);
		}

		public static async Task FromObject<T>(this FileStream fileStream, T @object, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			await ((Stream) fileStream).FromObject(@object, serializer, cancellationToken);
		}

		public static async Task FromArray<T>(this FileStream fileStream, T[] array, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			await ((Stream) fileStream).FromArray(array, serializer, cancellationToken);
		}
	}
}