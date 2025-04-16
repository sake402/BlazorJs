//// Licensed to the .NET Foundation under one or more agreements.
//// The .NET Foundation licenses this file to you under the MIT license.

//namespace System.Net.Http
//{
//    internal sealed partial class BrowserHttpWriteStream : Stream
//    {
//        private readonly BrowserHttpController _controller; // we don't own it, we don't dispose it from here
//        public BrowserHttpWriteStream(BrowserHttpController controller)
//        {
//            ArgumentNullException.ThrowIfNull(controller);

//            _controller = controller;
//        }

//        private Task WriteAsyncCore(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken)
//        {
//            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
//            _controller.ThrowIfDisposed();

//            // http_wasm_transform_stream_write makes a copy of the bytes synchronously, so we can dispose the handle synchronously
//            using MemoryHandle pinBuffer = buffer.Pin();
//            Task writePromise = BrowserHttpInterop.TransformStreamWriteUnsafe(_controller._jsController, buffer, pinBuffer);
//            return BrowserHttpInterop.CancellationHelper(writePromise, cancellationToken, _controller._jsController);
//        }

//        public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken)
//        {
//            return new ValueTask(WriteAsyncCore(buffer, cancellationToken));
//        }

//        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
//        {
//            ValidateBufferArguments(buffer, offset, count);
//            return WriteAsyncCore(new ReadOnlyMemory<byte>(buffer, offset, count), cancellationToken);
//        }

//        public override bool CanRead => false;
//        public override bool CanSeek => false;
//        public override bool CanWrite => true;

//        protected override void Dispose(bool disposing)
//        {
//        }

//        public override void Flush()
//        {
//        }

//        #region PlatformNotSupported

//        public override long Position
//        {
//            get => throw new NotSupportedException();
//            set => throw new NotSupportedException();
//        }
//        public override long Length => throw new NotSupportedException();
//        public override int Read(byte[] buffer, int offset, int count)
//        {
//            throw new NotSupportedException();
//        }

//        public override long Seek(long offset, SeekOrigin origin)
//        {
//            throw new NotSupportedException();
//        }

//        public override void SetLength(long value)
//        {
//            throw new NotSupportedException();
//        }

//        public override void Write(byte[] buffer, int offset, int count)
//        {
//            throw new NotSupportedException(SR.net_http_synchronous_writes_not_supported);
//        }
//        #endregion
//    }
//}
