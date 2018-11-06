using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JStreamAsyncNet
{
	public static class StreamExtensions
	{
		public static async Task<T> ToObject<T>(this Stream stream, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			using (stream)
			{
				using (var streamReader = new StreamReader(stream))
				{
					using (var reader = new JsonTextReader(streamReader))
					{
						var jObject = await JObject.LoadAsync(reader, cancellationToken).ConfigureAwait(false);
						return jObject.ToObject<T>(serializer ?? new JsonSerializer());
					}
				}
			}
		}

		public static async Task<T[]> ToArray<T>(this Stream stream, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			using (stream)
			{
				using (var streamReader = new StreamReader(stream))
				{
					using (var reader = new JsonTextReader(streamReader))
					{
						var jArray = await JArray.LoadAsync(reader, cancellationToken).ConfigureAwait(false);
						return jArray.ToObject<T[]>(serializer ?? new JsonSerializer());
					}
				}
			}
		}

		public static async Task FromObject<T>(this Stream stream, T @object, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			using (stream)
			{
				using (var writer = new StreamWriter(stream))
				{
					JsonWriter jsonTextWriter = new JsonTextWriter(writer);
					await JObject.FromObject(@object, serializer ?? new JsonSerializer())
						.WriteToAsync(jsonTextWriter, cancellationToken).ConfigureAwait(false);
				}
			}
		}

		public static async Task FromArray<T>(this Stream stream, T[] array, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			using (stream)
			{
				using (var writer = new StreamWriter(stream))
				{
					JsonWriter jsonTextWriter = new JsonTextWriter(writer);
					await JArray.FromObject(array, serializer ?? new JsonSerializer())
						.WriteToAsync(jsonTextWriter, cancellationToken).ConfigureAwait(false);
				}
			}
		}
	}

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