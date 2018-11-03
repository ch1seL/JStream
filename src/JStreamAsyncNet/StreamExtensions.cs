using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JStreamAsyncNet
{
	public static class StreamAsyncExtensions
	{
		public static async Task<T> ToObject<T>(this Task<Stream> stream, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			using (stream)
			{
				using (var streamReader = new StreamReader(await stream.ConfigureAwait(false)))
				{
					using (var reader = new JsonTextReader(streamReader))
					{
						var jObject = await JObject.LoadAsync(reader, cancellationToken).ConfigureAwait(false);
						return jObject.ToObject<T>(serializer ?? new JsonSerializer());
					}
				}
			}
		}

		public static async Task<T[]> ToArray<T>(this Task<Stream> stream, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			using (stream)
			{
				using (var streamReader = new StreamReader(await stream.ConfigureAwait(false)))
				{
					using (var reader = new JsonTextReader(streamReader))
					{
						var jArray = await JArray.LoadAsync(reader, cancellationToken).ConfigureAwait(false);
						return jArray.ToObject<T[]>(serializer ?? new JsonSerializer());
					}
				}
			}
		}

		public static async Task FromObject<T>(this Task<Stream> stream, T @object, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			using (stream)
			{
				using (var writer = new StreamWriter(await stream.ConfigureAwait(false)))
				{
					JsonWriter jsonTextWriter = new JsonTextWriter(writer);
					await JObject.FromObject(@object, serializer ?? new JsonSerializer())
						.WriteToAsync(jsonTextWriter, cancellationToken).ConfigureAwait(false);
				}
			}
		}

		public static async Task FromArray<T>(this Task<Stream> stream, T[] array, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			using (stream)
			{
				using (var writer = new StreamWriter(await stream.ConfigureAwait(false)))
				{
					JsonWriter jsonTextWriter = new JsonTextWriter(writer);
					await JArray.FromObject(array, serializer ?? new JsonSerializer())
						.WriteToAsync(jsonTextWriter, cancellationToken).ConfigureAwait(false);
				}
			}
		}
	}
}