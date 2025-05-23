// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace System.Net.Http.Headers
{
    /// <summary>Provides a view on top of a <see cref="HttpHeaders"/> collection that avoids forcing validation or parsing on its contents.</summary>
    /// <remarks>
    /// The view surfaces data as it's stored in the headers collection.  Any header values that have not yet been parsed / validated won't be
    /// as part of any accesses from this view, e.g. a raw header value of "one, two" that hasn't yet been parsed due to other operations
    /// on the <see cref="HttpHeaders"/> will be surfaced as a single header value rather than two.  For any header values that have already
    /// been parsed and validated, that value will be converted to a string to be returned from operations on this view.
    /// </remarks>
    public readonly partial struct HttpHeadersNonValidated : IReadOnlyDictionary<string, HeaderStringValues>
    {
        /// <summary>The wrapped headers collection.</summary>
        private readonly HttpHeaders _headers;

        /// <summary>Initializes the view.</summary>
        /// <param name="headers">The wrapped headers collection.</param>
        internal HttpHeadersNonValidated(HttpHeaders headers) => _headers = headers;

        /// <summary>Gets the number of headers stored in the collection.</summary>
        /// <remarks>Multiple header values associated with the same header name are considered to be one header as far as this count is concerned.</remarks>
        public int Count => _headers?.Count ?? 0;

        /// <summary>Gets whether the collection contains the specified header.</summary>
        /// <param name="headerName">The name of the header.</param>
        /// <returns>true if the collection contains the header; otherwise, false.</returns>
        public bool Contains(string headerName) =>
            _headers is HttpHeaders headers &&
            headers.TryGetHeaderDescriptor(headerName, out HeaderDescriptor descriptor) &&
            headers.Contains(descriptor);

        /// <summary>Gets the values for the specified header name.</summary>
        /// <param name="headerName">The name of the header.</param>
        /// <returns>The values for the specified header.</returns>
        /// <exception cref="KeyNotFoundException">The header was not contained in the collection.</exception>
        public HeaderStringValues this[string headerName]
        {
            get
            {
                if (TryGetValues(headerName, out HeaderStringValues values))
                {
                    return values;
                }

                throw new KeyNotFoundException("net_http_headers_not_found");
            }
        }

        /// <inheritdoc/>
        bool IReadOnlyDictionary<string, HeaderStringValues>.ContainsKey(string key) => Contains(key);

        /// <summary>Attempts to retrieve the values associated with the specified header name.</summary>
        /// <param name="headerName">The name of the header.</param>
        /// <param name="values">The retrieved header values.</param>
        /// <returns>true if the collection contains the specified header; otherwise, false.</returns>
        public bool TryGetValues(string headerName, out HeaderStringValues values)
        {
            if (_headers is HttpHeaders headers &&
                headers.TryGetHeaderDescriptor(headerName, out HeaderDescriptor descriptor) &&
                headers.TryGetHeaderValue(descriptor, out HeaderEntry info))
            {
                HttpHeaders.GetStoreValuesAsStringOrStringArray(descriptor, info, out string singleValue, out string[] multiValue);
                Debug.Assert(!(singleValue is null) ^ !(multiValue is null));
                values = !(singleValue is null) ?
                    new HeaderStringValues(descriptor, singleValue) :
                    new HeaderStringValues(descriptor, multiValue);
                return true;
            }

            values = default;
            return false;
        }

        /// <inheritdoc/>
        bool IReadOnlyDictionary<string, HeaderStringValues>.TryGetValue(string key, out HeaderStringValues value) => TryGetValues(key, out value);

        /// <summary>Gets an enumerator that iterates through the <see cref="HttpHeadersNonValidated"/>.</summary>
        /// <returns>An enumerator that iterates through the <see cref="HttpHeadersNonValidated"/>.</returns>
        public Enumerator GetEnumerator() =>
            _headers is HttpHeaders headers && headers.GetEntriesArray() is HeaderEntry[] entries ?
                new Enumerator(entries, headers.Count) :
                default;

        /// <inheritdoc/>
        IEnumerator<KeyValuePair<string, HeaderStringValues>> IEnumerable<KeyValuePair<string, HeaderStringValues>>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc/>
        IEnumerable<string> IReadOnlyDictionary<string, HeaderStringValues>.Keys
        {
            get
            {
                foreach (KeyValuePair<string, HeaderStringValues> header in this)
                {
                    yield return header.Key;
                }
            }
        }

        /// <inheritdoc/>
        IEnumerable<HeaderStringValues> IReadOnlyDictionary<string, HeaderStringValues>.Values
        {
            get
            {
                foreach (KeyValuePair<string, HeaderStringValues> header in this)
                {
                    yield return header.Value;
                }
            }
        }

        /// <summary>Enumerates the elements of a <see cref="HttpHeadersNonValidated"/>.</summary>
        public partial struct Enumerator : IEnumerator<KeyValuePair<string, HeaderStringValues>>
        {
            private readonly HeaderEntry[] _entries;
            private readonly int _numberOfEntries;
            private int _index;
            private KeyValuePair<string, HeaderStringValues> _current;

            internal Enumerator(HeaderEntry[] entries, int numberOfEntries)
            {
                _entries = entries;
                _numberOfEntries = numberOfEntries;
                _index = 0;
                _current = default;
            }

            /// <inheritdoc/>
            public bool MoveNext()
            {
                int index = _index;
                if (_entries is HeaderEntry[] entries && index < _numberOfEntries && (uint)index < (uint)entries.Length)
                {
                    HeaderEntry entry = entries[index];
                    _index++;

                    HttpHeaders.GetStoreValuesAsStringOrStringArray(entry.Key, entry.Value, out string singleValue, out string[] multiValue);
                    Debug.Assert(!(singleValue is null) ^ !(multiValue is null));

                    _current = new KeyValuePair<string, HeaderStringValues>(
                        entry.Key.Name,
                        !(singleValue is null) ? new HeaderStringValues(entry.Key, singleValue) : new HeaderStringValues(entry.Key, multiValue));
                    return true;
                }

                _current = default;
                return false;
            }

            /// <inheritdoc/>
            public KeyValuePair<string, HeaderStringValues> Current => _current;

            /// <inheritdoc/>
            object IEnumerator.Current => _current;

            /// <inheritdoc/>
            public void Dispose() { }

            /// <inheritdoc/>
            void IEnumerator.Reset() => throw new NotSupportedException();
        }
    }
}
