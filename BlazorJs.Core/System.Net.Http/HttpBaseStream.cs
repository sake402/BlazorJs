// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http
{
    internal abstract partial class HttpBaseStream : AsyncStream
    {
        public sealed override bool CanSeek => false;

        public sealed override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

        public sealed override void SetLength(long value) => throw new NotSupportedException();

        public sealed override long Length => throw new NotSupportedException();

        public sealed override long Position
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        public sealed override int ReadByte()
        {
            byte[] b = new byte[] { 0 };
            return Read(b, 0, 1) == 1 ? b[0] : -1;
        }

        //public sealed override int Read(byte[] buffer, int offset, int count)
        //{
        //    return Read(buffer.AsSpan(offset, count));
        //}

        public override void Write(byte[] buffer, int offset, int count)
        {
            // This does sync-over-async, but it also should only end up being used in strange
            // situations.  Either a derived stream overrides this anyway, so the implementation won't be used,
            // or it's being called as part of HttpContent.SerializeToStreamAsync, which means custom
            // content is explicitly choosing to make a synchronous call as part of an asynchronous method.
            WriteAsync(buffer, offset, count, CancellationToken.None).GetAwaiter().GetResult();
        }

        public sealed override void WriteByte(byte value) =>
            Write(new byte[] { value }, 0, 1);

        //public abstract int Read(Span<byte> buffer);
        //public abstract override Task<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken);
        //public abstract override Task WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken);
    }
}
