// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace System.Net.Http
{
    public partial class HttpMethod : IEquatable<HttpMethod>
    {
        private readonly string _method;
        private int _hashcode;

        public static HttpMethod Get { get; } = new HttpMethod("GET");
        public static HttpMethod Put { get; } = new HttpMethod("PUT");
        public static HttpMethod Post { get; } = new HttpMethod("POST");
        public static HttpMethod Delete { get; } = new HttpMethod("DELETE");
        public static HttpMethod Head { get; } = new HttpMethod("HEAD");
        public static HttpMethod Options { get; } = new HttpMethod("OPTIONS");
        public static HttpMethod Trace { get; } = new HttpMethod("TRACE");
        public static HttpMethod Patch { get; } = new HttpMethod("PATCH");

        /// <summary>Gets the HTTP CONNECT protocol method.</summary>
        /// <value>The HTTP CONNECT method.</value>
        public static HttpMethod Connect { get; } = new HttpMethod("CONNECT");

        public string Method => _method;

        public HttpMethod(string method)
        {
            if (string.IsNullOrEmpty(method))
                throw new ArgumentException();
            if (!HttpRuleParser.IsToken(method.AsSpan()))
            {
                throw new FormatException("net_http_httpmethod_format_error");
            }

            _method = method;
            //Initialize(method);
        }

        //private HttpMethod(string method, int http3StaticTableIndex)
        //{
        //    _method = method;
        //    //Initialize(http3StaticTableIndex);
        //}

        // SocketsHttpHandler-specific implementation has extra init logic.
        //partial void Initialize(int http3Index);
        //partial void Initialize(string method);

        public bool Equals(HttpMethod other) =>
            !(other is null) &&
            string.Equals(_method, other._method, StringComparison.OrdinalIgnoreCase);

        public override bool Equals(object obj) =>
            obj is HttpMethod method &&
            Equals(method);

        public override int GetHashCode()
        {
            if (_hashcode == 0)
            {
                _hashcode = StringComparer.OrdinalIgnoreCase.GetHashCode(_method);
            }

            return _hashcode;
        }

        public override string ToString() => _method;

        public static bool operator ==(HttpMethod left, HttpMethod right) =>
            ReferenceEquals(left, null) || ReferenceEquals(right, null) ?
                 ReferenceEquals(left, right)
                : left.Equals(right);

        public static bool operator !=(HttpMethod left, HttpMethod right) =>
            !(left == right);

        /// <summary>Parses the provided <paramref name="method"/> into an <see cref="HttpMethod"/> instance.</summary>
        /// <param name="method">The method to parse.</param>
        /// <returns>An <see cref="HttpMethod"/> instance for the provided <paramref name="method"/>.</returns>
        /// <remarks>
        /// This method may return a singleton instance for known methods; for example, it may return <see cref="Get"/>
        /// if "GET" is specified. The parsing is performed in a case-insensitive manner, so it may also return <see cref="Get"/>
        /// if "get" is specified. For unknown methods, a new <see cref="HttpMethod"/> instance is returned, with the
        /// same validation being performed as by the <see cref="HttpMethod(string)"/> constructor.
        /// </remarks>
        public static HttpMethod Parse(ReadOnlySpan<char> method) =>
            GetKnownMethod(method) ??
            new HttpMethod(method.ToString());

        internal static HttpMethod GetKnownMethod(ReadOnlySpan<char> method)
        {
            if (method.Length >= 3) // 3 == smallest known method
            {
                HttpMethod match = null;
                switch (method[0] | 0x20)
                {
                    case 'c':
                        match = Connect;
                        break;
                    case 'd':
                        match = Delete;
                        break;
                    case 'g':
                        match = Get;
                        break;
                    case 'h':
                        match = Head;
                        break;
                    case 'o':
                        match = Options;
                        break;
                    case 'p':
                        switch (method.Length)
                        {
                            case 3:
                                match = Put;
                                break;
                            case 4:
                                match = Post;
                                break;
                            default:
                                match = Patch;
                                break;
                        }
                        match = Head;
                        break;
                        case 't':
                        match = Trace;
                        break;
                }
                if (!(match is null) &&
                    method.IsEqual(match._method, StringComparison.OrdinalIgnoreCase))
                {
                    return match;
                }
            }

            return null;
        }
    }
}
