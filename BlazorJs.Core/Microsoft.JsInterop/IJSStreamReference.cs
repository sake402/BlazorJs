// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.JSInterop
{

    /// <summary>
    /// Represents a reference to JavaScript data to be consumed through a <see cref="Stream"/>.
    /// </summary>
    public interface IJSStreamReference : IDisposable// IAsyncDisposable
    {
        /// <summary>
        /// Length of the <see cref="Stream"/> provided by JavaScript.
        /// </summary>
        long Length { get; }

        /// <summary>
        /// Opens a <see cref="Stream"/> with the <see cref="JSRuntime"/> for the current data reference.
        /// </summary>
        /// <param name="maxAllowedSize">Maximum number of bytes permitted to be read from JavaScript.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken" /> for cancelling read.</param>
        /// <returns><see cref="Stream"/> which can provide data associated with the current data reference.</returns>
        Task<Stream> OpenReadStreamAsync(long maxAllowedSize = 512000, CancellationToken cancellationToken = default);
    }
}