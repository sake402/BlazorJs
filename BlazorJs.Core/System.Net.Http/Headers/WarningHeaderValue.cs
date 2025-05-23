// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace System.Net.Http.Headers
{
    public partial class WarningHeaderValue : ICloneable
    {
        private readonly int _code;
        private readonly string _agent;
        private readonly string _text;
        private readonly DateTimeOffset _date;
        private readonly bool _dateHasValue;

        public int Code => _code;

        public string Agent => _agent;

        public string Text => _text;

        public DateTimeOffset? Date => _dateHasValue ? _date : (DateTimeOffset?)null;

        private WarningHeaderValue(int code, string agent, string text, DateTimeOffset? date)
        {
#if DEBUG
            // This constructor should only be used with already validated values.
            new WarningHeaderValue(code, agent, text);
#endif

            _code = code;
            _agent = agent;
            _text = text;
            _date = date.GetValueOrDefault();
            _dateHasValue = date.HasValue;
        }

        public WarningHeaderValue(int code, string agent, string text)
        {
            CheckCode(code);
            CheckAgent(agent);
            HeaderUtilities.CheckValidQuotedString(text);

            _code = code;
            _agent = agent;
            _text = text;
        }

        public WarningHeaderValue(int code, string agent, string text, DateTimeOffset date)
        {
            CheckCode(code);
            CheckAgent(agent);
            HeaderUtilities.CheckValidQuotedString(text);

            _code = code;
            _agent = agent;
            _text = text;
            _date = date;
            _dateHasValue = true;
        }

        private WarningHeaderValue(WarningHeaderValue source)
        {
            Debug.Assert(source != null);

            _code = source._code;
            _agent = source._agent;
            _text = source._text;
            _date = source._date;
            _dateHasValue = source._dateHasValue;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            // Warning codes are always 3 digits according to RFC2616
            sb.Append(_code.ToString("000"));

            sb.Append(' ');
            sb.Append(_agent);
            sb.Append(' ');
            sb.Append(_text);

            if (_dateHasValue)
            {
                sb.Append(" \"");
                sb.Append(_date.ToString("r"));
                sb.Append('\"');
            }

            return sb.ToString();
        }

        public override bool Equals(object obj) =>
            obj is WarningHeaderValue other &&
            _code == other._code &&
            // 'agent' is a host/token, i.e. use case-insensitive comparison. Use case-sensitive comparison for 'text'
            // since it is a quoted string.
            string.Equals(_agent, other._agent, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(_text, other._text, StringComparison.Ordinal) &&
            _dateHasValue == other._dateHasValue &&
            _date == other._date;

        public override int GetHashCode() =>
            HashCode.Combine(
                _code,
                StringComparer.OrdinalIgnoreCase.GetHashCode(_agent),
                _text,
                _dateHasValue,
                _date);

        public static WarningHeaderValue Parse(string input)
        {
            int index = 0;
            return (WarningHeaderValue)GenericHeaderParser.SingleValueWarningParser.ParseValue(input, null, ref index);
        }

        public static bool TryParse(string input, out WarningHeaderValue parsedValue)
        {
            int index = 0;
            parsedValue = null;

            if (GenericHeaderParser.SingleValueWarningParser.TryParseValue(input, null, ref index, out object output))
            {
                parsedValue = (WarningHeaderValue)output;
                return true;
            }
            return false;
        }

        internal static int GetWarningLength(string input, int startIndex, out object parsedValue)
        {
            Debug.Assert(startIndex >= 0);

            parsedValue = null;

            if (string.IsNullOrEmpty(input) || (startIndex >= input.Length))
            {
                return 0;
            }

            // Read <code> in '<code> <agent> <text> ["<date>"]'
            int current = startIndex;

            if (!TryReadCode(input, ref current, out int code))
            {
                return 0;
            }

            // Read <agent> in '<code> <agent> <text> ["<date>"]'
            if (!TryReadAgent(input, ref current, out string agent))
            {
                return 0;
            }

            // Read <text> in '<code> <agent> <text> ["<date>"]'
            int textStartIndex = current;
            if (HttpRuleParser.GetQuotedStringLength(input, current, out int textLength) != HttpParseResult.Parsed)
            {
                return 0;
            }

            string text = input.Substring(textStartIndex, textLength);

            current += textLength;

            // Read <date> in '<code> <agent> <text> ["<date>"]'
            if (!TryReadDate(input, ref current, out DateTimeOffset? date))
            {
                return 0;
            }

            parsedValue = new WarningHeaderValue(code, agent, text, date);

            return current - startIndex;
        }

        private static bool TryReadAgent(string input, ref int current, out string agent)
        {
            agent = null;

            int agentLength = HttpRuleParser.GetHostLength(input, current, true);
            if (agentLength == 0)
            {
                return false;
            }

            agent = input.Substring(current, agentLength);
            current += agentLength;

            int whitespaceLength = HttpRuleParser.GetWhitespaceLength(input, current);
            current += whitespaceLength;

            // At least one whitespace required after <agent>. Also make sure we have characters left for <text>
            if ((whitespaceLength == 0) || (current == input.Length))
            {
                return false;
            }

            return true;
        }

        private static bool TryReadCode(string input, ref int current, out int code)
        {
            code = 0;
            int codeLength = HttpRuleParser.GetNumberLength(input, current, false);

            // code must be a 3 digit value. We accept less digits, but we don't accept more.
            if ((codeLength == 0) || (codeLength > 3))
            {
                return false;
            }

            if (!HeaderUtilities.TryParseInt32(input, current, codeLength, out code))
            {
                Debug.Fail("Unable to parse value even though it was parsed as <=3 digits string. Input: '" +
                    input + "', Current: " + current + ", CodeLength: " + codeLength);
                return false;
            }

            current += codeLength;

            int whitespaceLength = HttpRuleParser.GetWhitespaceLength(input, current);
            current += whitespaceLength;

            // Make sure the number is followed by at least one whitespace and that we have characters left to parse.
            if ((whitespaceLength == 0) || (current == input.Length))
            {
                return false;
            }

            return true;
        }

        private static bool TryReadDate(string input, ref int current, out DateTimeOffset? date)
        {
            date = null;

            // Make sure we have at least one whitespace between <text> and <date> (if we have <date>)
            int whitespaceLength = HttpRuleParser.GetWhitespaceLength(input, current);
            current += whitespaceLength;

            // Read <date> in '<code> <agent> <text> ["<date>"]'
            if ((current < input.Length) && (input[current] == '"'))
            {
                if (whitespaceLength == 0)
                {
                    return false; // we have characters after <text> but they were not separated by a whitespace
                }

                current++; // skip opening '"'

                // Find the closing '"'
                int dateStartIndex = current;
                int quote = input.AsSpan(current).IndexOf('"');
                if (quote <= 0) // no quote was found or it was the first character (meaning an empty quoted string)
                {
                    return false;
                }
                current += quote;

                if (!DateTimeOffset.TryParse(input.AsSpan(dateStartIndex, current - dateStartIndex), out DateTimeOffset temp))
                {
                    return false;
                }

                date = temp;

                current++; // skip closing '"'
                current += HttpRuleParser.GetWhitespaceLength(input, current);
            }

            return true;
        }

        object ICloneable.Clone()
        {
            return new WarningHeaderValue(this);
        }

        private static void CheckCode(int code)
        {
            if (code < 0 || code > 999)
                throw new ArgumentOutOfRangeException();
        }

        private static void CheckAgent(string agent)
        {
            if (string.IsNullOrEmpty(agent))
                throw new ArgumentException();

            // 'Agent' can either be a host or a token. Since a token is a valid host, we only verify if the value
            // is a valid host.
            if (HttpRuleParser.GetHostLength(agent, 0, true) != agent.Length)
            {
                throw new FormatException("net_http_headers_invalid_value");
            }
        }
    }
}
