using H5;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace System.Web
{
    public static class HttpUtility
    {
        [Template("encodeURI({0})")]
        public static extern string UrlEncode(string uri);
        public static NameValueCollection ParseQueryString(string query)
        {
            Span<Range> ranges = new Span<Range>(50);
            var span = query.AsSpan().Trim('?');
            int len = span.Split(ranges, '&');
            NameValueCollection collection = new NameValueCollection();
            for (int i = 0; i < len; i++)
            {
                var kv = span[ranges[i]];
                Span<Range> innerRanges = new Span<Range>(2);
                var ilen = kv.Split(innerRanges, '=');
                string value = null;
                string key = kv[innerRanges[0]];
                if (ilen > 1)
                {
                    value = kv[innerRanges[0]];
                }
                collection.Add(key, value);
            }
            return collection;
        }
    }
}
