// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;

namespace System.Net.Http.Headers
{
    public sealed partial class HttpResponseHeaders : HttpHeaders
    {
        private const int AcceptRangesSlot = 0;
        private const int ProxyAuthenticateSlot = 1;
        private const int ServerSlot = 2;
        private const int VarySlot = 3;
        private const int WwwAuthenticateSlot = 4;
        private const int NumCollectionsSlots = 5;

        private object[] _specialCollectionsSlots;
        private HttpGeneralHeaders _generalHeaders;
        private readonly bool _containsTrailingHeaders;

        #region Response Headers

        private T GetSpecializedCollection<T>(int slot, Func<HttpResponseHeaders, T> creationFunc)
        {
            // 5 properties each lazily allocate a collection to store the value(s) for that property.
            // Rather than having a field for each of these, store them untyped in an array that's lazily
            // allocated.  Then we only pay for the 45 bytes for those fields when any is actually accessed.
            object[] collections = _specialCollectionsSlots = _specialCollectionsSlots ?? new object[NumCollectionsSlots];
            return (T)(collections[slot] = collections[slot] ?? creationFunc(this));
        }

        public HttpHeaderValueCollection<string> AcceptRanges =>
            GetSpecializedCollection(AcceptRangesSlot, thisRef => new HttpHeaderValueCollection<string>(KnownHeaders.AcceptRanges.Descriptor, thisRef));

        public TimeSpan? Age
        {
            get { return HeaderUtilities.GetTimeSpanValue(KnownHeaders.Age.Descriptor, this); }
            set { SetOrRemoveParsedValue(KnownHeaders.Age.Descriptor, value); }
        }

        public EntityTagHeaderValue ETag
        {
            get { return (EntityTagHeaderValue)GetSingleParsedValue(KnownHeaders.ETag.Descriptor); }
            set { SetOrRemoveParsedValue(KnownHeaders.ETag.Descriptor, value); }
        }

        public Uri Location
        {
            get { return (Uri)GetSingleParsedValue(KnownHeaders.Location.Descriptor); }
            set { SetOrRemoveParsedValue(KnownHeaders.Location.Descriptor, value); }
        }

        public HttpHeaderValueCollection<AuthenticationHeaderValue> ProxyAuthenticate =>
            GetSpecializedCollection(ProxyAuthenticateSlot, thisRef => new HttpHeaderValueCollection<AuthenticationHeaderValue>(KnownHeaders.ProxyAuthenticate.Descriptor, thisRef));

        public RetryConditionHeaderValue RetryAfter
        {
            get { return (RetryConditionHeaderValue)GetSingleParsedValue(KnownHeaders.RetryAfter.Descriptor); }
            set { SetOrRemoveParsedValue(KnownHeaders.RetryAfter.Descriptor, value); }
        }

        public HttpHeaderValueCollection<ProductInfoHeaderValue> Server =>
            GetSpecializedCollection(ServerSlot, thisRef => new HttpHeaderValueCollection<ProductInfoHeaderValue>(KnownHeaders.Server.Descriptor, thisRef));

        public HttpHeaderValueCollection<string> Vary =>
            GetSpecializedCollection(VarySlot, thisRef => new HttpHeaderValueCollection<string>(KnownHeaders.Vary.Descriptor, thisRef));

        public HttpHeaderValueCollection<AuthenticationHeaderValue> WwwAuthenticate =>
            GetSpecializedCollection(WwwAuthenticateSlot, thisRef => new HttpHeaderValueCollection<AuthenticationHeaderValue>(KnownHeaders.WWWAuthenticate.Descriptor, thisRef));

        #endregion

        #region General Headers

        public CacheControlHeaderValue CacheControl
        {
            get { return GeneralHeaders.CacheControl; }
            set { GeneralHeaders.CacheControl = value; }
        }

        public HttpHeaderValueCollection<string> Connection
        {
            get { return GeneralHeaders.Connection; }
        }

        public bool? ConnectionClose
        {
            get { return HttpGeneralHeaders.GetConnectionClose(this, _generalHeaders); } // special-cased to avoid forcing _generalHeaders initialization
            set { GeneralHeaders.ConnectionClose = value; }
        }

        public DateTimeOffset? Date
        {
            get { return GeneralHeaders.Date; }
            set { GeneralHeaders.Date = value; }
        }

        public HttpHeaderValueCollection<NameValueHeaderValue> Pragma
        {
            get { return GeneralHeaders.Pragma; }
        }

        public HttpHeaderValueCollection<string> Trailer
        {
            get { return GeneralHeaders.Trailer; }
        }

        public HttpHeaderValueCollection<TransferCodingHeaderValue> TransferEncoding
        {
            get { return GeneralHeaders.TransferEncoding; }
        }

        public bool? TransferEncodingChunked
        {
            get { return HttpGeneralHeaders.GetTransferEncodingChunked(this, _generalHeaders); } // special-cased to avoid forcing _generalHeaders initialization
            set { GeneralHeaders.TransferEncodingChunked = value; }
        }

        public HttpHeaderValueCollection<ProductHeaderValue> Upgrade
        {
            get { return GeneralHeaders.Upgrade; }
        }

        public HttpHeaderValueCollection<ViaHeaderValue> Via
        {
            get { return GeneralHeaders.Via; }
        }

        public HttpHeaderValueCollection<WarningHeaderValue> Warning
        {
            get { return GeneralHeaders.Warning; }
        }

        #endregion

        internal HttpResponseHeaders(bool containsTrailingHeaders = false)
            : base(containsTrailingHeaders ? HttpHeaderType.All ^ HttpHeaderType.Request : HttpHeaderType.General | HttpHeaderType.Response | HttpHeaderType.Custom,
                  HttpHeaderType.Request)
        {
            _containsTrailingHeaders = containsTrailingHeaders;
        }

        internal bool ContainsTrailingHeaders => _containsTrailingHeaders;

        internal override void AddHeaders(HttpHeaders sourceHeaders)
        {
            base.AddHeaders(sourceHeaders);
            HttpResponseHeaders sourceResponseHeaders = sourceHeaders as HttpResponseHeaders;
            Debug.Assert(sourceResponseHeaders != null);

            // Copy special values, but do not overwrite
            if (sourceResponseHeaders._generalHeaders != null)
            {
                GeneralHeaders.AddSpecialsFrom(sourceResponseHeaders._generalHeaders);
            }
        }

        internal override bool IsAllowedHeaderName(HeaderDescriptor descriptor)
        {
            if (!_containsTrailingHeaders)
                return true;

            KnownHeader knownHeader = KnownHeaders.TryGetKnownHeader(descriptor.Name);
            if (knownHeader == null)
                return true;

            return (knownHeader.HeaderType & HttpHeaderType.NonTrailing) == 0;
        }

        private HttpGeneralHeaders GeneralHeaders => _generalHeaders = _generalHeaders ?? new HttpGeneralHeaders(this);
    }
}
