using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace JStreamAsyncNet
{
    public static class StreamExtensions
    {
        public static async Task<T> ToObjectAsync<T>(this Stream stream, JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            await using (stream)
            {
                return await JsonSerializer.DeserializeAsync<T>(stream, options, cancellationToken);
            }
        }

        public static async Task<T[]> ToArrayAsync<T>(this Stream stream, JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return await stream.ToObjectAsync<T[]>(options, cancellationToken);
        }

        public static async Task WriteFromObjectAsync<T>(this Stream stream, T @object,
            JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            await using (stream)
            {
                await JsonSerializer.SerializeAsync(stream, @object, options, cancellationToken);
            }
        }

        public static async Task WriteFromArrayAsync<T>(this Stream stream, T[] array,
            JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            await stream.WriteFromObjectAsync(array, options, cancellationToken);
        }
    }
}