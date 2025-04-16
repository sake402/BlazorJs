// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http
{
    public abstract partial class HttpMessageHandler : IDisposable
    {
        protected HttpMessageHandler()
        {
        }

        // We cannot add abstract member to a public partial class in order to not to break already established contract of this class.
        // So we add virtual method, override it everywhere internally and provide proper implementation.
        // Unfortunately we cannot force everyone to implement so in such case we throw NSE.
        protected internal virtual HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        protected internal abstract Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            // Nothing to do in base class.
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
