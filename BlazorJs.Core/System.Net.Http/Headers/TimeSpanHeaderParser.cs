// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Globalization;

namespace System.Net.Http.Headers
{
    internal sealed partial class TimeSpanHeaderParser : BaseHeaderParser
    {
        internal static readonly TimeSpanHeaderParser Parser = new TimeSpanHeaderParser();

        private TimeSpanHeaderParser()
            : base(false)
        {
        }

        public override string ToString(object value)
        {
            Debug.Assert(value is TimeSpan);

            return ((int)((TimeSpan)value).TotalSeconds).ToString();
        }

        protected override int GetParsedValueLength(string value, int startIndex, object storeValue,
            out object parsedValue)
        {
            parsedValue = null;

            int numberLength = HttpRuleParser.GetNumberLength(value, startIndex, false);

            if ((numberLength == 0) || (numberLength > HttpRuleParser.MaxInt32Digits))
            {
                return 0;
            }

            int result;
            if (!HeaderUtilities.TryParseInt32(value, startIndex, numberLength, out result))
            {
                return 0;
            }

            parsedValue = new TimeSpan(0, 0, result);
            return numberLength;
        }
    }
}
