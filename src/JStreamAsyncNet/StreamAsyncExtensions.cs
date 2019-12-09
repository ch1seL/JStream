using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace JStreamAsyncNet
{
    public static class StreamAsyncExtensions
    {
        public static async Task<T> ToObjectAsync<T>(this Task<Stream> streamTask,
            JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            var stream = await streamTask.ConfigureAwait(false);
            return await stream.ToObjectAsync<T>(options, cancellationToken).ConfigureAwait(false);
        }

        public static async Task<T[]> ToArrayAsync<T>(this Task<Stream> streamTask,
            JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            var stream = await streamTask.ConfigureAwait(false);
            return await stream.ToArrayAsync<T>(options, cancellationToken).ConfigureAwait(false);
        }

        public static async Task FromObjectAsync<T>(this Task<Stream> streamTask, T @object,
            JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            var stream = await streamTask.ConfigureAwait(false);
            await stream.WriteFromObjectAsync(@object, options, cancellationToken).ConfigureAwait(false);
        }

        public static async Task FromArrayAsync<T>(this Task<Stream> streamTask, T[] array,
            JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            var stream = await streamTask.ConfigureAwait(false);
            await stream.WriteFromArrayAsync(array, options, cancellationToken).ConfigureAwait(false);
        }
    }
}