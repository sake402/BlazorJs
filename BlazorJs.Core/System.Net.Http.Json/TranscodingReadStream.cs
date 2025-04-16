// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// Taken from https://github.com/dotnet/aspnetcore/blob/master/src/Mvc/Mvc.Core/src/Formatters/TranscodingReadStream.cs

using System.Buffers;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http.Json
{
    internal sealed partial class TranscodingReadStream : AsyncStream
    {
        private static readonly int OverflowBufferSize = Encoding.UTF8.GetMaxByteCount(1); // The most number of bytes used to represent a single UTF char

        // Default size of the buffer that will hold the bytes from the underlying stream.
        // Those bytes are expected to be encoded in the sourceEncoding passed into the .ctor.
        internal const int MaxByteBufferSize = 4096;

        private readonly Stream _stream;
        private readonly Decoder _decoder;
        private readonly Encoder _encoder;

        private Span<byte> _byteBuffer;
        private Span<char> _charBuffer;
        private Span<byte> _overflowBuffer;
        private bool _disposed;

        public TranscodingReadStream(Stream input, Encoding sourceEncoding)
        {
            _stream = input;

            // The "count" in the buffer is the size of any content from a previous read.
            // Initialize them to 0 since nothing has been read so far.
            _byteBuffer = new Span<byte>(ArrayPool<byte>.Shared.Rent(MaxByteBufferSize), 0, length: 0);

            // Attempt to allocate a char buffer than can tolerate the worst-case scenario for this
            // encoding. This would allow the byte -> char conversion to complete in a single call.
            // The conversion process is tolerant of char buffer that is not large enough to convert all the bytes at once.
            int maxCharBufferSize = sourceEncoding.GetMaxCharCount(MaxByteBufferSize);
            _charBuffer = new Span<char>(ArrayPool<char>.Shared.Rent(maxCharBufferSize), 0, length: 0);

            _overflowBuffer = new Span<byte>(ArrayPool<byte>.Shared.Rent(OverflowBufferSize), 0, length: 0);

            _decoder = sourceEncoding.GetDecoder();
            _encoder = Encoding.UTF8.GetEncoder();
        }

        public override bool CanRead => true;
        public override bool CanSeek => false;
        public override bool CanWrite => false;
        public override long Length => throw new NotSupportedException();

        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        internal int ByteBufferCount => _byteBuffer.Count;
        internal int CharBufferCount => _charBuffer.Count;
        internal int OverflowCount => _overflowBuffer.Count;

        public override int Read(byte[] buffer, int offset, int count)
            => throw new NotSupportedException();

        public override Task<int> ReadAsync(Span<byte> buffer, CancellationToken cancellationToken)
        {
            //if (buffer is null)
            //{
            //    throw new ArgumentNullException(nameof(buffer));
            //}
            return ReadAsyncCore(buffer, cancellationToken);
        }

        private async Task<int> ReadAsyncCore(Span<byte> readBuffer, CancellationToken cancellationToken)
        {
            if (readBuffer.Length == 0)
            {
                return 0;
            }

            if (_overflowBuffer.Count > 0)
            {
                int bytesToCopy = Math.Min(readBuffer.Length, _overflowBuffer.Count);
                _overflowBuffer.Slice(0, bytesToCopy).CopyTo(readBuffer);

                _overflowBuffer = _overflowBuffer.Slice(bytesToCopy);

                // If we have any overflow bytes, avoid complicating the remainder of the code, by returning as
                // soon as we copy any content.
                return bytesToCopy;
            }

            bool shouldFlushEncoder = false;
            // Only read more content from the input stream if we have exhausted all the buffered chars.
            if (_charBuffer.Count == 0)
            {
                int bytesRead = await ReadInputChars(cancellationToken);
                shouldFlushEncoder = bytesRead == 0 && _byteBuffer.Count == 0;
            }

            bool completed = false;
            int charsRead = default;
            int bytesWritten = default;
            // Since Convert() could fail if the destination buffer cannot fit at least one encoded char.
            // If the destination buffer is smaller than GetMaxByteCount(1), we avoid encoding to the destination and we use the overflow buffer instead.
            if (readBuffer.Count > OverflowBufferSize || _charBuffer.Count == 0)
            {
                _encoder.Convert(_charBuffer.Array, _charBuffer.Offset, _charBuffer.Count, readBuffer.Array, readBuffer.Offset, readBuffer.Count,
                    shouldFlushEncoder, out charsRead, out bytesWritten, out completed);
            }

            _charBuffer = _charBuffer.Slice(charsRead);

            if (completed || bytesWritten > 0)
            {
                return bytesWritten;
            }

            _encoder.Convert(_charBuffer.Array, _charBuffer.Offset, _charBuffer.Count, _overflowBuffer.Array, 0, _overflowBuffer.Array.Length,
                shouldFlushEncoder, out int overFlowChars, out int overflowBytes, out _);

            Debug.Assert(overflowBytes > 0 && overFlowChars > 0, "We expect writes to the overflow buffer to always succeed since it is large enough to accommodate at least one char.");

            _charBuffer = _charBuffer.Slice(overFlowChars);

            // readBuffer: [ 0, 0, ], overflowBuffer: [ 7, 13, 34, ]
            // Fill up the readBuffer to capacity, so the result looks like so:
            // readBuffer: [ 7, 13 ], overflowBuffer: [ 34 ]
            Debug.Assert(readBuffer.Count < overflowBytes);
            _overflowBuffer.Array.AsSpan(0, readBuffer.Count).CopyTo(readBuffer);

            Debug.Assert(_overflowBuffer.Array != null);

            _overflowBuffer = new Span<byte>(_overflowBuffer.Array, readBuffer.Count, overflowBytes - readBuffer.Count);

            Debug.Assert(_overflowBuffer.Count > 0);

            return readBuffer.Count;
        }

        private async Task<int> ReadInputChars(CancellationToken cancellationToken)
        {
            // If we had left-over bytes from a previous read, move it to the start of the buffer and read content into
            // the segment that follows.
            Debug.Assert(_byteBuffer.Array != null);
            Array.Copy(_byteBuffer.Array, _byteBuffer.Offset, _byteBuffer.Array, 0, _byteBuffer.Count);
            //Buffer.BlockCopy(_byteBuffer.Array, _byteBuffer.Offset, _byteBuffer.Array, 0, _byteBuffer.Count);

            int offset = _byteBuffer.Count;
            int count = _byteBuffer.Array.Length - _byteBuffer.Count;

            int bytesRead = await _stream.ReadAsync(_byteBuffer.Array, offset, count, cancellationToken);

            _byteBuffer = new Span<byte>(_byteBuffer.Array, 0, offset + bytesRead);

            Debug.Assert(_byteBuffer.Array != null);
            Debug.Assert(_charBuffer.Array != null);
            Debug.Assert(_charBuffer.Count == 0, "We should only expect to read more input chars once all buffered content is read");

            _decoder.Convert(_byteBuffer.Array, _byteBuffer.Offset, _byteBuffer.Count, _charBuffer.Array, 0, _charBuffer.Array.Length,
                bytesRead == 0, out int bytesUsed, out int charsUsed, out _);

            // We flush only when the stream is exhausted and there are no pending bytes in the buffer.
            Debug.Assert(bytesRead != 0 || _byteBuffer.Count - bytesUsed == 0);

            _byteBuffer = _byteBuffer.Slice(bytesUsed);
            _charBuffer = new Span<char>(_charBuffer.Array, 0, charsUsed);

            return bytesRead;
        }

        public override void Flush()
            => throw new NotSupportedException();

        public override long Seek(long offset, SeekOrigin origin)
            => throw new NotSupportedException();

        public override void SetLength(long value)
            => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count)
            => throw new NotSupportedException();

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;

                char[] charBuffer = _charBuffer.Array;
                Debug.Assert(charBuffer != null);
                _charBuffer = default;
                ArrayPool<char>.Shared.Return(charBuffer);

                byte[] byteBuffer = _byteBuffer.Array;
                Debug.Assert(byteBuffer != null);
                _byteBuffer = default;
                ArrayPool<byte>.Shared.Return(byteBuffer);

                byte[] overflowBuffer = _overflowBuffer.Array;
                Debug.Assert(overflowBuffer != null);
                _overflowBuffer = default;
                ArrayPool<byte>.Shared.Return(overflowBuffer);

                _stream.Dispose();
            }
        }

        public override Task<int> WriteAsync(ReadOnlySpan<byte> buffer, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
