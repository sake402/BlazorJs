// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Text;

namespace System.Net.Http
{
    public partial class HttpResponseMessage : IDisposable
    {
        private const HttpStatusCode DefaultStatusCode = HttpStatusCode.OK;
        private static Version DefaultResponseVersion => HttpVersion.Version11;

        private HttpStatusCode _statusCode;
        private HttpResponseHeaders _headers;
        private HttpResponseHeaders _trailingHeaders;
        private string _reasonPhrase;
        private HttpRequestMessage _requestMessage;
        private Version _version;
        private HttpContent _content;
        private bool _disposed;

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

        internal void SetVersionWithoutValidation(Version value) => _version = value;

        public HttpContent Content
        {
            get { return _content = _content ?? new EmptyContent(); }
            set
            {
                CheckDisposed();
                _content = value;
            }
        }

        public HttpStatusCode StatusCode
        {
            get { return _statusCode; }
            set
            {
                if (value < 0 || value > (HttpStatusCode)999)
                    throw new ArgumentOutOfRangeException();
                CheckDisposed();

                _statusCode = value;
            }
        }

        internal void SetStatusCodeWithoutValidation(HttpStatusCode value) => _statusCode = value;

        public string ReasonPhrase
        {
            get
            {
                if (_reasonPhrase != null)
                {
                    return _reasonPhrase;
                }
                // Provide a default if one was not set.
                return StatusCode.ToString();// HttpStatusDescription.Get(StatusCode);
            }
            set
            {
                if ((value != null) && HttpRuleParser.ContainsNewLine(value))
                {
                    throw new FormatException("net_http_reasonphrase_format_error");
                }
                CheckDisposed();

                _reasonPhrase = value; // It's OK to have a 'null' reason phrase.
            }
        }

        internal void SetReasonPhraseWithoutValidation(string value) => _reasonPhrase = value;

        public HttpResponseHeaders Headers => _headers = _headers ?? new HttpResponseHeaders();

        public HttpResponseHeaders TrailingHeaders => _trailingHeaders = _trailingHeaders ?? new HttpResponseHeaders(containsTrailingHeaders: true);

        /// <summary>Stores the supplied trailing headers into this instance.</summary>
        /// <remarks>
        /// In the common/desired case where response.TrailingHeaders isn't accessed until after the whole payload has been
        /// received, <see cref="_trailingHeaders" /> will still be null, and we can simply store the supplied instance into
        /// <see cref="_trailingHeaders" /> and assume ownership of the instance.  In the uncommon case where it was accessed,
        /// we add all of the headers to the existing instance.
        /// </remarks>
        internal void StoreReceivedTrailingHeaders(HttpResponseHeaders headers)
        {
            Debug.Assert(headers.ContainsTrailingHeaders);

            if (_trailingHeaders is null)
            {
                _trailingHeaders = headers;
            }
            else
            {
                _trailingHeaders.AddHeaders(headers);
            }
        }

        public HttpRequestMessage RequestMessage
        {
            get { return _requestMessage; }
            set
            {
                CheckDisposed();
                _requestMessage = value;
            }
        }

        public bool IsSuccessStatusCode
        {
            get { return ((int)_statusCode >= 200) && ((int)_statusCode <= 299); }
        }

        public HttpResponseMessage()
            : this(DefaultStatusCode)
        {
        }

        public HttpResponseMessage(HttpStatusCode statusCode)
        {
            if (statusCode < 0 || statusCode > (HttpStatusCode)999)
                throw new ArgumentOutOfRangeException();

            _statusCode = statusCode;
            _version = DefaultResponseVersion;
        }

        public HttpResponseMessage EnsureSuccessStatusCode()
        {
            if (!IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    string.IsNullOrWhiteSpace(ReasonPhrase) ? "net_http_message_not_success_statuscode" : "net_http_message_not_success_statuscode_reason",
                    null,
                    _statusCode);
            }

            return this;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("StatusCode: ");
            sb.Append((int)_statusCode);

            sb.Append(", ReasonPhrase: '");
            sb.Append(ReasonPhrase ?? "<null>");

            sb.Append("', Version: ");
            sb.Append(_version);

            sb.Append(", Content: ");
            sb.Append(_content == null ? "<null>" : _content.GetType().ToString());

            sb.AppendLine(", Headers:");
            HeaderUtilities.DumpHeaders(sb, _headers, _content?.Headers);

            if (_trailingHeaders != null)
            {
                sb.AppendLine(", Trailing Headers:");
                HeaderUtilities.DumpHeaders(sb, _trailingHeaders);
            }

            return sb.ToString();
        }

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            // The reason for this type to implement IDisposable is that it contains instances of types that implement
            // IDisposable (content).
            if (disposing && !_disposed)
            {
                _disposed = true;
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
            if (_disposed)
                throw new ObjectDisposedException("");
        }
    }
}
