using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JStreamAsyncNet
{
	public static class StreamExtensions
	{
		public static async Task<T> ToObjectAsync<T>(this Stream stream, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			using (stream)
			{
				using (var streamReader = new StreamReader(stream))
				{
					using (var reader = new JsonTextReader(streamReader))
					{
						JToken jToken = await JToken.LoadAsync(reader, cancellationToken).ConfigureAwait(false);
						return jToken.ToObject<T>(serializer ?? new JsonSerializer());
					}
				}
			}
		}

		public static async Task<T[]> ToArrayAsync<T>(this Stream stream, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			return await stream.ToObjectAsync<T[]>(serializer, cancellationToken);
		}

		public static async Task FromObjectAsync<T>(this Stream stream, T @object, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			using (stream)
			{
				using (var writer = new StreamWriter(stream))
				{
					JsonWriter jsonTextWriter = new JsonTextWriter(writer);
					await JToken.FromObject(@object, serializer ?? new JsonSerializer())
						.WriteToAsync(jsonTextWriter, cancellationToken).ConfigureAwait(false);
				}
			}
		}

		public static async Task FromArrayAsync<T>(this Stream stream, T[] array, JsonSerializer serializer = null,
			CancellationToken cancellationToken = default)
		{
			await stream.FromObjectAsync(array, serializer, cancellationToken);
		}
	}
}