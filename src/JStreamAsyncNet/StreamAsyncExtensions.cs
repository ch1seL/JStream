using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JStreamAsyncNet
{
	public static class StreamAsyncExtensions
	{
		public static async Task<T> ToObject<T>(this Task<Stream> streamTask, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			var stream = await streamTask.ConfigureAwait(false);
			return await stream.ToObject<T>(serializer, cancellationToken).ConfigureAwait(false);
		}

		public static async Task<T[]> ToArray<T>(this Task<Stream> streamTask, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			var stream = await streamTask.ConfigureAwait(false);
			return await stream.ToArray<T>(serializer, cancellationToken).ConfigureAwait(false);
		}

		public static async Task FromObject<T>(this Task<Stream> streamTask, T @object,
			JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			var stream = await streamTask.ConfigureAwait(false);
			await stream.FromObject(@object, serializer, cancellationToken).ConfigureAwait(false);
		}

		public static async Task FromArray<T>(this Task<Stream> streamTask, T[] array, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			var stream = await streamTask.ConfigureAwait(false);
			await stream.FromArray(array, serializer, cancellationToken).ConfigureAwait(false);
		}
	}
}