// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// Taken from https://github.com/dotnet/aspnetcore/blob/master/src/Mvc/Mvc.Core/src/Formatters/TranscodingWriteStream.cs

using System.Buffers;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http.Json
{
    internal sealed partial class TranscodingWriteStream : AsyncStream
    {
        // Default size of the char buffer that will hold the passed-in bytes when decoded from UTF-8.
        // The buffer holds them and then they are encoded to the targetEncoding and written to the underlying stream.
        internal const int MaxCharBufferSize = 4096;
        // Upper bound that limits the byte buffer size to prevent an encoding that has a very poor worst-case scenario.
        internal const int MaxByteBufferSize = 4 * MaxCharBufferSize;
        private readonly int _maxByteBufferSize;

        private readonly Stream _stream;
        private readonly Decoder _decoder;
        private readonly Encoder _encoder;
        private char[] _charBuffer;
        private int _charsDecoded;
        private bool _disposed;

        public TranscodingWriteStream(Stream stream, Encoding targetEncoding)
        {
            _stream = stream;

            _charBuffer = ArrayPool<char>.Shared.Rent(MaxCharBufferSize);

            // Attempt to allocate a byte buffer than can tolerate the worst-case scenario for this
            // encoding. This would allow the char -> byte conversion to complete in a single call.
            // However limit the buffer size to prevent an encoding that has a very poor worst-case scenario.
            _maxByteBufferSize = Math.Min(MaxByteBufferSize, targetEncoding.GetMaxByteCount(MaxCharBufferSize));

            _decoder = Encoding.UTF8.GetDecoder();
            _encoder = targetEncoding.GetEncoder();
        }

        public override bool CanRead => false;
        public override bool CanSeek => false;
        public override bool CanWrite => true;
        public override long Length => throw new NotSupportedException();
        public override long Position { get; set; }

        public override void Flush()
            => throw new NotSupportedException();

        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            _stream.Flush();
            return Task.CompletedTask;
        }

        public override int Read(byte[] buffer, int offset, int count)
            => throw new NotSupportedException();

        public override long Seek(long offset, SeekOrigin origin)
            => throw new NotSupportedException();

        public override void SetLength(long value)
            => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count)
            => throw new NotSupportedException();

        public override Task<int> WriteAsync(ReadOnlySpan<byte> buffer, CancellationToken cancellationToken)
        {
            //if (buffer is null)
            //{
            //    throw new ArgumentNullException(nameof(buffer));
            //}

            return WriteAsyncCore(buffer, cancellationToken);
        }

        private async Task<int> WriteAsyncCore(ReadOnlySpan<byte> bufferSegment, CancellationToken cancellationToken)
        {
            bool decoderCompleted = false;
            int len = 0;

            while (!decoderCompleted)
            {
                //_decoder.Convert(bufferSegment.Array, bufferSegment.Offset, bufferSegment.Count, _charBuffer, _charsDecoded, _charBuffer.Length - _charsDecoded,
                //    flush: false, out int bytesDecoded, out int charsDecoded, out decoderCompleted);
                _decoder.Convert(bufferSegment.ToArray(), 0, bufferSegment.Length, _charBuffer, _charsDecoded, _charBuffer.Length - _charsDecoded,
                    false, out int bytesDecoded, out int charsDecoded, out decoderCompleted);
                len += bytesDecoded;
                _charsDecoded += charsDecoded;
                bufferSegment = bufferSegment.Slice(bytesDecoded);
                await WriteBufferAsync(cancellationToken);
            }
            return len;
        }

        private async Task WriteBufferAsync(CancellationToken cancellationToken)
        {
            bool encoderCompleted = false;
            int charsWritten = 0;
            byte[] byteBuffer = ArrayPool<byte>.Shared.Rent(_maxByteBufferSize);

            while (!encoderCompleted && charsWritten < _charsDecoded)
            {
                _encoder.Convert(_charBuffer, charsWritten, _charsDecoded - charsWritten, byteBuffer, 0, byteBuffer.Length,
                    false, out int charsEncoded, out int bytesUsed, out encoderCompleted);

                await _stream.WriteAsync(byteBuffer, 0, bytesUsed, cancellationToken);
                charsWritten += charsEncoded;
            }

            ArrayPool<byte>.Shared.Return(byteBuffer);

            // At this point, we've written all the buffered chars to the underlying Stream.
            _charsDecoded = 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                char[] toReturn = _charBuffer;
                _charBuffer = null;
                ArrayPool<char>.Shared.Return(toReturn);
            }
        }

        public async Task FinalWriteAsync(CancellationToken cancellationToken)
        {
            // Flush the encoder.
            byte[] byteBuffer = ArrayPool<byte>.Shared.Rent(_maxByteBufferSize);
            bool encoderCompleted = false;

            while (!encoderCompleted)
            {
                _encoder.Convert(Array.Empty<char>(), 0, 0, byteBuffer, 0, byteBuffer.Length,
                    true, out _, out int bytesUsed, out encoderCompleted);

                await _stream.WriteAsync(byteBuffer, 0, bytesUsed, cancellationToken);
            }

            ArrayPool<byte>.Shared.Return(byteBuffer);
        }

        public override Task<int> ReadAsync(Span<byte> buffer, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
