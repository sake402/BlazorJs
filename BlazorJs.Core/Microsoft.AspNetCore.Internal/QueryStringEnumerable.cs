//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Text;

//namespace Microsoft.AspNetCore.Internal
//{
//    internal readonly struct QueryStringEnumerable
//    {
//        private readonly ReadOnlySpan<char> _queryString;

//        /// <summary>
//        /// Constructs an instance of <see cref="QueryStringEnumerable"/>.
//        /// </summary>
//        /// <param name="queryString">The query string.</param>
//        public QueryStringEnumerable(string queryString)
//            : this(queryString.AsSpan())
//        {
//        }

//        /// <summary>
//        /// Constructs an instance of <see cref="QueryStringEnumerable"/>.
//        /// </summary>
//        /// <param name="queryString">The query string.</param>
//        public QueryStringEnumerable(ReadOnlySpan<char> queryString)
//        {
//            _queryString = queryString;
//        }

//        /// <summary>
//        /// Retrieves an object that can iterate through the name/value pairs in the query string.
//        /// </summary>
//        /// <returns>An object that can iterate through the name/value pairs in the query string.</returns>
//        public Enumerator GetEnumerator()
//            => new Enumerator(_queryString);

//        /// <summary>
//        /// Represents a single name/value pair extracted from a query string during enumeration.
//        /// </summary>
//        public readonly partial struct EncodedNameValuePair
//        {
//            /// <summary>
//            /// Gets the name from this name/value pair in its original encoded form.
//            /// To get the decoded string, call <see cref="DecodeName"/>.
//            /// </summary>
//            public ReadOnlySpan<char> EncodedName { get; }

//            /// <summary>
//            /// Gets the value from this name/value pair in its original encoded form.
//            /// To get the decoded string, call <see cref="DecodeValue"/>.
//            /// </summary>
//            public ReadOnlySpan<char> EncodedValue { get; }

//            internal EncodedNameValuePair(ReadOnlySpan<char> encodedName, ReadOnlySpan<char> encodedValue)
//            {
//                EncodedName = encodedName;
//                EncodedValue = encodedValue;
//            }

//            /// <summary>
//            /// Decodes the name from this name/value pair.
//            /// </summary>
//            /// <returns>Characters representing the decoded name.</returns>
//            public ReadOnlySpan<char> DecodeName()
//                => Decode(EncodedName);

//            /// <summary>
//            /// Decodes the value from this name/value pair.
//            /// </summary>
//            /// <returns>Characters representing the decoded value.</returns>
//            public ReadOnlySpan<char> DecodeValue()
//                => Decode(EncodedValue);

//            private static ReadOnlySpan<char> Decode(ReadOnlySpan<char> chars)
//            {
//                ReadOnlySpan<char> source = chars;
//                if (!source.ContainsAny('%', '+'))
//                {
//                    return chars;
//                }
//                var buffer = new char[source.Length];
//                source.CopyTo(buffer);
//                for (int i = 0; i < source.Length; i++)
//                {
//                    if (buffer[i] == '+')
//                        buffer[i] = ' ';
//                }
//                //source.Replace(buffer, '+', ' ');
//                UriExtension.Decode(buffer, buffer, out var unescapedLength);
//                //Debug.Assert(success);
//                return new ReadOnlySpan<char>(buffer, 0, unescapedLength);
//            }
//        }

//        /// <summary>
//        /// An enumerator that supplies the name/value pairs from a URI query string.
//        /// </summary>
//        public partial struct Enumerator
//        {
//            private ReadOnlySpan<char> _query;

//            internal Enumerator(ReadOnlySpan<char> query)
//            {
//                Current = default;
//                _query = query.IsEmpty || query[0] != '?'
//                    ? query
//                    : query.Slice(1);
//            }

//            /// <summary>
//            /// Gets the currently referenced key/value pair in the query string being enumerated.
//            /// </summary>
//            public EncodedNameValuePair Current { get; private set; }

//            /// <summary>
//            /// Moves to the next key/value pair in the query string being enumerated.
//            /// </summary>
//            /// <returns>True if there is another key/value pair, otherwise false.</returns>
//            public bool MoveNext()
//            {
//                while (!_query.IsEmpty)
//                {
//                    // Chomp off the next segment
//                    ReadOnlySpan<char> segment;
//                    var delimiterIndex = _query.IndexOf('&');
//                    if (delimiterIndex >= 0)
//                    {
//                        segment = _query.Slice(0, delimiterIndex);
//                        _query = _query.Slice(delimiterIndex + 1);
//                    }
//                    else
//                    {
//                        segment = _query;
//                        _query = default;
//                    }

//                    // If it's nonempty, emit it
//                    var equalIndex = segment.IndexOf('=');
//                    if (equalIndex >= 0)
//                    {
//                        Current = new EncodedNameValuePair(
//                            segment.Slice(0, equalIndex),
//                            segment.Slice(equalIndex + 1));
//                        return true;
//                    }
//                    else if (!segment.IsEmpty)
//                    {
//                        Current = new EncodedNameValuePair(segment, default);
//                        return true;
//                    }
//                }

//                Current = default;
//                return false;
//            }
//        }
//    }
//}
