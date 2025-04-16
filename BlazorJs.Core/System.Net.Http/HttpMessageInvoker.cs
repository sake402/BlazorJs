// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http
{
    public partial class HttpMessageInvoker : IDisposable
    {
        private volatile bool _disposed;
        private readonly bool _disposeHandler;
        private readonly HttpMessageHandler _handler;

        public HttpMessageInvoker(HttpMessageHandler handler)
            : this(handler, true)
        {
        }

        public HttpMessageInvoker(HttpMessageHandler handler, bool disposeHandler)
        {
            _handler = handler;
            _disposeHandler = disposeHandler;
        }

        public virtual HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return _handler.Send(request, cancellationToken);
        }

        public virtual Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return _handler.SendAsync(request, cancellationToken);
        }
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _disposed = true;
                if (_disposeHandler)
                {
                    _handler.Dispose();
                }
            }
        }
    }
}
