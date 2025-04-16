using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BlazorJs.Core;

namespace System.IO
{
    public abstract partial class AsyncStream : Stream
    {
        public sealed override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state) =>
            TaskToAsyncResult.Begin(ReadAsync(buffer, offset, count, default), callback, state);

        public sealed override int EndRead(IAsyncResult asyncResult) =>
            TaskToAsyncResult.End<int>(asyncResult);

        public sealed override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state) =>
            TaskToAsyncResult.Begin(WriteAsync(buffer, offset, count, default), callback, state);

        public sealed override void EndWrite(IAsyncResult asyncResult) =>
            TaskToAsyncResult.End(asyncResult);

        public abstract Task<int> WriteAsync(ReadOnlySpan<byte> buffer, CancellationToken cancellationToken);
        public abstract Task<int> ReadAsync(Span<byte> buffer, CancellationToken cancellationToken);
        public Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            => ReadAsync(new Span<byte>(buffer, offset, count), cancellationToken);
        public Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            => WriteAsync(new ReadOnlySpan<byte>(buffer, offset, count), cancellationToken);
        public virtual Task FlushAsync(CancellationToken cancellationToken) => NopAsync(cancellationToken);
        public override void Flush()
        {
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            WriteAsync(buffer, offset, count, CancellationToken.None).FireAndForget();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return ReadAsync(buffer, offset, count, CancellationToken.None).GetAwaiter().GetResult();
        }

        protected static Task NopAsync(CancellationToken cancellationToken) =>
            cancellationToken.IsCancellationRequested ? throw new TaskCanceledException() :
            Task.CompletedTask;
    }
}
