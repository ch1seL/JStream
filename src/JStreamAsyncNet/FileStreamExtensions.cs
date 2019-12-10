using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace JStreamAsyncNet
{
    public static class FileStreamExtensions
    {
        public static Task<T> ToObjectAsync<T>(this FileStream fileStream,
            JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return ((Stream) fileStream).ToObjectAsync<T>(options, cancellationToken);
        }

        public static Task<T[]> ToArrayAsync<T>(this FileStream fileStream,
            JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return ((Stream) fileStream).ToArrayAsync<T>(options, cancellationToken);
        }

        public static async Task WriteFromObjectAsync<T>(this FileStream fileStream, T @object,
            JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            await ((Stream) fileStream).WriteFromObjectAsync(@object, options, cancellationToken).ConfigureAwait(false);
        }

        public static async Task WriteFromArrayAsync<T>(this FileStream fileStream, T[] array,
            JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            await ((Stream) fileStream).WriteFromArrayAsync(array, options, cancellationToken).ConfigureAwait(false);
        }
    }
}