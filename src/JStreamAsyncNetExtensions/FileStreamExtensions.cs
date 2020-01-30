using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Newtonsoft.Json.JStreamAsyncNetExtensions
{
    public static class FileStreamExtensions
    {
        public static Task<T> ToObjectAsync<T>(this FileStream fileStream, JsonSerializer serializer = null,
            CancellationToken cancellationToken = default)
        {
            return ((Stream) fileStream).ToObjectAsync<T>(serializer, cancellationToken);
        }

        public static Task<T[]> ToArrayAsync<T>(this FileStream fileStream, JsonSerializer serializer = null,
            CancellationToken cancellationToken = default)
        {
            return ((Stream) fileStream).ToArrayAsync<T>(serializer, cancellationToken);
        }

        public static async Task WriteFromObjectAsync<T>(this FileStream fileStream, T @object,
            JsonSerializer serializer = null,
            CancellationToken cancellationToken = default)
        {
            await ((Stream) fileStream).WriteFromObjectAsync(@object, serializer, cancellationToken);
        }

        public static async Task WriteFromArrayAsync<T>(this FileStream fileStream, T[] array,
            JsonSerializer serializer = null,
            CancellationToken cancellationToken = default)
        {
            await ((Stream) fileStream).WriteFromArrayAsync(array, serializer, cancellationToken);
        }
    }
}