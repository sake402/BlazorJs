// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http
{
    /// <summary>Provides a zero-length HttpContent implementation.</summary>
    internal sealed partial class EmptyContent : HttpContent
    {
        protected internal override bool TryComputeLength(out long length)
        {
            length = 0;
            return true;
        }

        protected override void SerializeToStream(Stream stream, CancellationToken cancellationToken)
        { }

        protected override Task SerializeToStreamAsync(Stream stream) =>
            Task.CompletedTask;

        protected override Task SerializeToStreamAsync(Stream stream, CancellationToken cancellationToken) =>
            cancellationToken.IsCancellationRequested ? throw new TaskCanceledException() :
            SerializeToStreamAsync(stream);

        protected override Stream CreateContentReadStream(CancellationToken cancellationToken) =>
            EmptyReadStream.Instance;

        protected override Task<Stream> CreateContentReadStreamAsync() =>
            Task.FromResult<Stream>(EmptyReadStream.Instance);

        protected override Task<Stream> CreateContentReadStreamAsync(CancellationToken cancellationToken) =>
            cancellationToken.IsCancellationRequested ? throw new TaskCanceledException() :
            CreateContentReadStreamAsync();

        internal override Stream TryCreateContentReadStream() => EmptyReadStream.Instance;

        internal override bool AllowDuplex => false;
    }
}
