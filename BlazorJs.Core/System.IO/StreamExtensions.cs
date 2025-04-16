using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.IO
{
    public static partial class StreamExtensions
    {
        public static Task<int> WriteAsync(this Stream stream, byte[] data, CancellationToken cancellationToken = default)
        {
            stream.Write(data, 0, data.Length);
            return Task.FromResult(data.Length);
        }

        public static Task<int> WriteAsync(this Stream stream, byte[] data, int offset, int count, CancellationToken cancellationToken = default)
        {
            stream.Write(data, offset, count);
            return Task.FromResult(data.Length);
        }

        public static Task<int> WriteAsync(this Stream stream, ReadOnlySpan<byte> data, CancellationToken cancellationToken = default)
        {
            data.CopyTo(stream);
            return Task.FromResult(data.Length);
        }

        public static Task<int> ReadAsync(this Stream stream, byte[] buffer, int offset, int count, CancellationToken cancellationToken = default)
        {
            int len = stream.Read(buffer, offset, count);
            return Task.FromResult(len);
        }

        public static Task<int> ReadAsync(this Stream stream, Span<byte> buffer, CancellationToken cancellationToken = default)
        {
            var len = buffer.CopyFrom(stream);
            return Task.FromResult(len);
        }

        public static Task CopyToAsync(this Stream stream, Stream destination, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static Task CopyToAsync(this Stream stream, Stream destination, int bufferSize, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
