// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;

namespace System.Net.Http
{
    public partial class HttpRequestMessage : IDisposable
    {
        internal static Version DefaultRequestVersion => HttpVersion.Version11;
        internal static HttpVersionPolicy DefaultVersionPolicy => HttpVersionPolicy.RequestVersionOrLower;

        private const int MessageNotYetSent = 0;
        private const int MessageAlreadySent = 1;
        private const int MessageIsRedirect = 2;
        private const int MessageDisposed = 4;

        // Track whether the message has been sent.
        // The message shouldn't be sent again if this field is equal to MessageAlreadySent.
        private int _sendStatus = MessageNotYetSent;

        private HttpMethod _method;
        private Uri _requestUri;
        private HttpRequestHeaders _headers;
        private Version _version;
        private HttpVersionPolicy _versionPolicy;
        private HttpContent _content;
        internal HttpRequestOptions _options;

        public Version Version
        {
            get { return _version; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                CheckDisposed();

                _version = value;
            }
        }

        /// <summary>
        /// Gets or sets the policy determining how <see cref="Version" /> is interpreted and how is the final HTTP version negotiated with the server.
        /// </summary>
        public HttpVersionPolicy VersionPolicy
        {
            get { return _versionPolicy; }
            set
            {
                CheckDisposed();

                _versionPolicy = value;
            }
        }

        public HttpContent Content
        {
            get { return _content; }
            set
            {
                CheckDisposed();
                // It's OK to set a 'null' content, even if the method is POST/PUT.
                _content = value;
            }
        }

        public HttpMethod Method
        {
            get { return _method; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                CheckDisposed();

                _method = value;
            }
        }

        public Uri RequestUri
        {
            get { return _requestUri; }
            set
            {
                CheckDisposed();
                _requestUri = value;
            }
        }

        public HttpRequestHeaders Headers => _headers = _headers ?? new HttpRequestHeaders();

        internal bool HasHeaders => _headers != null;

        [Obsolete("HttpRequestMessage.Properties has been deprecated. Use Options instead.")]
        public IDictionary<string, object> Properties => Options;

        /// <summary>
        /// Gets the collection of options to configure the HTTP request.
        /// </summary>
        public HttpRequestOptions Options => _options = _options ?? new HttpRequestOptions();

        public HttpRequestMessage()
            : this(HttpMethod.Get, (Uri)null)
        {
        }

        public HttpRequestMessage(HttpMethod method, Uri requestUri)
        {
            if (method == null)
                throw new ArgumentNullException();

            // It's OK to have a 'null' request Uri. If HttpClient is used, the 'BaseAddress' will be added.
            // If there is no 'BaseAddress', sending this request message will throw.
            // Note that we also allow the string to be empty: null and empty are considered equivalent.
            _method = method;
            _requestUri = requestUri;
            _version = DefaultRequestVersion;
            _versionPolicy = DefaultVersionPolicy;
        }

        public HttpRequestMessage(HttpMethod method, string requestUri)
            : this(method, string.IsNullOrEmpty(requestUri) ? null : new Uri(requestUri/*, UriKind.RelativeOrAbsolute*/))
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Method: ");
            sb.Append(_method);

            sb.Append(", RequestUri: '");
            if (_requestUri is null)
            {
                sb.Append("<null>");
            }
            else
            {
                sb.Append($"{_requestUri}");
            }

            sb.Append("', Version: ");
            sb.Append(_version);

            sb.Append(", Content: ");
            sb.Append(_content == null ? "<null>" : _content.GetType().ToString());

            sb.AppendLine(", Headers:");
            HeaderUtilities.DumpHeaders(sb, _headers, _content?.Headers);

            return sb.ToString();
        }

        internal bool MarkAsSent()
        {            
            return InterlockedExtension.CompareExchange(ref _sendStatus, MessageAlreadySent, MessageNotYetSent) == MessageNotYetSent;
        }

        internal bool WasSentByHttpClient() => (_sendStatus & MessageAlreadySent) != 0;

        internal void MarkAsRedirected() => _sendStatus |= MessageIsRedirect;

        internal bool WasRedirected() => (_sendStatus & MessageIsRedirect) != 0;

        private bool Disposed
        {
            get => (_sendStatus & MessageDisposed) != 0;
            set
            {
                Debug.Assert(value);
                _sendStatus |= MessageDisposed;
            }
        }

        internal bool IsExtendedConnectRequest => Method == HttpMethod.Connect && _headers?.Protocol != null;

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            // The reason for this type to implement IDisposable is that it contains instances of types that implement
            // IDisposable (content).
            if (disposing && !Disposed)
            {
                Disposed = true;
                _content?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion

        private void CheckDisposed()
        {
            if (Disposed)
                throw new ObjectDisposedException("");
        }
    }
}
