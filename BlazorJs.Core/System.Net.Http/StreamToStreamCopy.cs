// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http
{
    /// <summary>
    /// Helper class is used to copy the content of a source stream to a destination stream,
    /// with optimizations based on expected usage within HttpClient and with the ability
    /// to dispose of the source stream when the copy has completed.
    /// </summary>
    internal static partial class StreamToStreamCopy
    {
        /// <summary>Copies the source stream from its current position to the destination stream at its current position.</summary>
        /// <param name="source">The source stream from which to copy.</param>
        /// <param name="destination">The destination stream to which to copy.</param>
        /// <param name="bufferSize">The size of the buffer to allocate if one needs to be allocated. If zero, use the default buffer size.</param>
        /// <param name="disposeSource">Whether to dispose of the source stream after the copy has finished successfully.</param>
        public static void Copy(Stream source, Stream destination, int bufferSize, bool disposeSource)
        {
            Debug.Assert(source != null);
            Debug.Assert(destination != null);
            Debug.Assert(bufferSize >= 0);

            if (bufferSize == 0)
            {
                source.CopyTo(destination);
            }
            else
            {
                source.CopyTo(destination, bufferSize);
            }

            if (disposeSource)
            {
                DisposeSource(source);
            }
        }

        /// <summary>Copies the source stream from its current position to the destination stream at its current position.</summary>
        /// <param name="source">The source stream from which to copy.</param>
        /// <param name="destination">The destination stream to which to copy.</param>
        /// <param name="bufferSize">The size of the buffer to allocate if one needs to be allocated. If zero, use the default buffer size.</param>
        /// <param name="disposeSource">Whether to dispose of the source stream after the copy has finished successfully.</param>
        /// <param name="cancellationToken">CancellationToken used to cancel the copy operation.</param>
        public static Task CopyAsync(Stream source, Stream destination, int bufferSize, bool disposeSource, CancellationToken cancellationToken = default(CancellationToken))
        {
            Debug.Assert(source != null);
            Debug.Assert(destination != null);
            Debug.Assert(bufferSize >= 0);

            try
            {
                Task copyTask = bufferSize == 0 ?
                    source.CopyToAsync(destination, cancellationToken) :
                    source.CopyToAsync(destination, bufferSize, cancellationToken);

                if (!disposeSource)
                {
                    return copyTask;
                }

                switch (copyTask.Status)
                {
                    case TaskStatus.RanToCompletion:
                        DisposeSource(source);
                        return Task.CompletedTask;

                    case TaskStatus.Faulted:
                    case TaskStatus.Canceled:
                        return copyTask;

                    default:
                        return DisposeSourceAsync(copyTask, source);

                        async Task DisposeSourceAsync(Task mcopyTask, Stream msource)
                        {
                            await mcopyTask;
                            DisposeSource(msource);
                        }
                }
            }
            catch (Exception e)
            {
                // For compatibility with the previous implementation, catch everything (including arg exceptions) and
                // store errors into the task rather than letting them propagate to the synchronous caller.
                //return Task.FromException(e);
                throw e;
            }
        }

        /// <summary>Disposes the source stream.</summary>
        private static void DisposeSource(Stream source)
        {
            try
            {
                source.Dispose();
            }
            catch (Exception e)
            {
                // Dispose() should never throw, but since we're on an async codepath, make sure to catch the exception.
            }
        }
    }
}
