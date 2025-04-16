// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http
{
    internal sealed partial class EmptyReadStream : HttpBaseStream
    {
        internal static EmptyReadStream Instance { get; } = new EmptyReadStream();

        private EmptyReadStream() { }

        public override bool CanRead => true;
        public override bool CanWrite => false;

        protected override void Dispose(bool disposing) {  /* nop */ }
        public override void Close() { /* nop */ }

        public override Task<int> ReadAsync(Span<byte> buffer, CancellationToken cancellationToken)
        {
            return cancellationToken.IsCancellationRequested ? throw new TaskCanceledException() :
            Task.FromResult(0);
        }

        public override Task<int> WriteAsync(ReadOnlySpan<byte> buffer, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("net_http_content_readonly_stream");
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return 0;
        }
    }
}
