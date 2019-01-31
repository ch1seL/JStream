using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JStreamAsyncNet
{
	public static class StreamAsyncExtensions
	{
		public static async Task<T> ToObjectAsync<T>(this Task<Stream> streamTask, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			var stream = await streamTask.ConfigureAwait(false);
			return await stream.ToObjectAsync<T>(serializer, cancellationToken).ConfigureAwait(false);
		}

		public static async Task<T[]> ToArrayAsync<T>(this Task<Stream> streamTask, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			var stream = await streamTask.ConfigureAwait(false);
			return await stream.ToArrayAsync<T>(serializer, cancellationToken).ConfigureAwait(false);
		}

		public static async Task FromObjectAsync<T>(this Task<Stream> streamTask, T @object,
			JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			var stream = await streamTask.ConfigureAwait(false);
			await stream.WriteFromObjectAsync(@object, serializer, cancellationToken).ConfigureAwait(false);
		}

		public static async Task FromArrayAsync<T>(this Task<Stream> streamTask, T[] array,
			JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			var stream = await streamTask.ConfigureAwait(false);
			await stream.WriteFromArrayAsync(array, serializer, cancellationToken).ConfigureAwait(false);
		}
	}
}