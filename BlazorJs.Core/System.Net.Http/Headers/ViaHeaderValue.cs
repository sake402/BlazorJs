// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace System.Net.Http.Headers
{
    public partial class ViaHeaderValue : ICloneable
    {
        private readonly string _protocolName;
        private readonly string _protocolVersion;
        private readonly string _receivedBy;
        private readonly string _comment;

        public string ProtocolName => _protocolName;

        public string ProtocolVersion => _protocolVersion;

        public string ReceivedBy => _receivedBy;

        public string Comment => _comment;

        private ViaHeaderValue(string protocolVersion, string receivedBy, string protocolName, string comment, bool _)
        {
#if DEBUG
            // This constructor should only be used with already validated values.
            new ViaHeaderValue(protocolVersion, receivedBy, protocolName, comment);
#endif

            _protocolVersion = protocolVersion;
            _receivedBy = receivedBy;
            _protocolName = protocolName;
            _comment = comment;
        }

        public ViaHeaderValue(string protocolVersion, string receivedBy)
            : this(protocolVersion, receivedBy, null, null)
        {
        }

        public ViaHeaderValue(string protocolVersion, string receivedBy, string protocolName)
            : this(protocolVersion, receivedBy, protocolName, null)
        {
        }

        public ViaHeaderValue(string protocolVersion, string receivedBy, string protocolName, string comment)
        {
            HeaderUtilities.CheckValidToken(protocolVersion);
            CheckReceivedBy(receivedBy);

            if (!string.IsNullOrEmpty(protocolName))
            {
                HeaderUtilities.CheckValidToken(protocolName);
                _protocolName = protocolName;
            }

            if (!string.IsNullOrEmpty(comment))
            {
                HeaderUtilities.CheckValidComment(comment);
                _comment = comment;
            }

            _protocolVersion = protocolVersion;
            _receivedBy = receivedBy;
        }

        private ViaHeaderValue(ViaHeaderValue source)
        {
            Debug.Assert(source != null);

            _protocolName = source._protocolName;
            _protocolVersion = source._protocolVersion;
            _receivedBy = source._receivedBy;
            _comment = source._comment;
        }

        public override string ToString()
        {
            var sb = new StringBuilder((256));

            if (!string.IsNullOrEmpty(_protocolName))
            {
                sb.Append(_protocolName);
                sb.Append('/');
            }

            sb.Append(_protocolVersion);
            sb.Append(' ');
            sb.Append(_receivedBy);

            if (!string.IsNullOrEmpty(_comment))
            {
                sb.Append(' ');
                sb.Append(_comment);
            }

            return sb.ToString();
        }

        public override bool Equals(object obj) =>
            obj is ViaHeaderValue other &&
            // Note that for token and host case-insensitive comparison is used. Comments are compared using case-
            // sensitive comparison.
            string.Equals(_protocolVersion, other._protocolVersion, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(_receivedBy, other._receivedBy, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(_protocolName, other._protocolName, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(_comment, other._comment, StringComparison.Ordinal);

        public override int GetHashCode() =>
            HashCode.Combine(
                StringComparer.OrdinalIgnoreCase.GetHashCode(_protocolVersion),
                StringComparer.OrdinalIgnoreCase.GetHashCode(_receivedBy),
                _protocolName is null ? 0 : StringComparer.OrdinalIgnoreCase.GetHashCode(_protocolName),
                _comment);

        public static ViaHeaderValue Parse(string input)
        {
            int index = 0;
            return (ViaHeaderValue)GenericHeaderParser.SingleValueViaParser.ParseValue(input, null, ref index);
        }

        public static bool TryParse(string input, out ViaHeaderValue parsedValue)
        {
            int index = 0;
            parsedValue = null;

            if (GenericHeaderParser.SingleValueViaParser.TryParseValue(input, null, ref index, out object output))
            {
                parsedValue = (ViaHeaderValue)output;
                return true;
            }
            return false;
        }

        internal static int GetViaLength(string input, int startIndex, out object parsedValue)
        {
            Debug.Assert(startIndex >= 0);

            parsedValue = null;

            if (string.IsNullOrEmpty(input) || (startIndex >= input.Length))
            {
                return 0;
            }

            // Read <protocolName> and <protocolVersion> in '[<protocolName>/]<protocolVersion> <receivedBy> [<comment>]'
            int current = GetProtocolEndIndex(input, startIndex, out string protocolName, out string protocolVersion);

            // If we reached the end of the string after reading protocolName/Version we return (we expect at least
            // <receivedBy> to follow). If reading protocolName/Version read 0 bytes, we return.
            if ((current == 0) || (current == input.Length))
            {
                return 0;
            }
            Debug.Assert(protocolVersion != null);

            // Read <receivedBy> in '[<protocolName>/]<protocolVersion> <receivedBy> [<comment>]'
            int receivedByLength = HttpRuleParser.GetHostLength(input, current, true);
            if (receivedByLength == 0)
            {
                return 0;
            }

            string receivedBy = input.Substring(current, receivedByLength);
            current += receivedByLength;

            current += HttpRuleParser.GetWhitespaceLength(input, current);

            string comment = null;
            if ((current < input.Length) && (input[current] == '('))
            {
                // We have a <comment> in '[<protocolName>/]<protocolVersion> <receivedBy> [<comment>]'
                if (HttpRuleParser.GetCommentLength(input, current, out int commentLength) != HttpParseResult.Parsed)
                {
                    return 0; // We found a '(' character but it wasn't a valid comment. Abort.
                }

                comment = input.Substring(current, commentLength);

                current += commentLength;
                current += HttpRuleParser.GetWhitespaceLength(input, current);
            }

            parsedValue = new ViaHeaderValue(protocolVersion, receivedBy, protocolName, comment, false);
            return current - startIndex;
        }

        private static int GetProtocolEndIndex(string input, int startIndex, out string protocolName,
            out string protocolVersion)
        {
            // We have a string of the form '[<protocolName>/]<protocolVersion> <receivedBy> [<comment>]'. The first
            // token may either be the protocol name or protocol version. We'll only find out after reading the token
            // and by looking at the following character: If it is a '/' we just parsed the protocol name, otherwise
            // the protocol version.
            protocolName = null;
            protocolVersion = null;

            int current = startIndex;
            int protocolVersionOrNameLength = HttpRuleParser.GetTokenLength(input, current);

            if (protocolVersionOrNameLength == 0)
            {
                return 0;
            }

            current = startIndex + protocolVersionOrNameLength;
            int whitespaceLength = HttpRuleParser.GetWhitespaceLength(input, current);
            current += whitespaceLength;

            if (current == input.Length)
            {
                return 0;
            }

            if (input[current] == '/')
            {
                // We parsed the protocol name
                protocolName = input.Substring(startIndex, protocolVersionOrNameLength);

                current++; // skip the '/' delimiter
                current += HttpRuleParser.GetWhitespaceLength(input, current);

                protocolVersionOrNameLength = HttpRuleParser.GetTokenLength(input, current);

                if (protocolVersionOrNameLength == 0)
                {
                    return 0; // We have a string "<token>/" followed by non-token chars. This is invalid.
                }

                protocolVersion = input.Substring(current, protocolVersionOrNameLength);

                current += protocolVersionOrNameLength;
                whitespaceLength = HttpRuleParser.GetWhitespaceLength(input, current);
                current += whitespaceLength;
            }
            else
            {
                protocolVersion = input.Substring(startIndex, protocolVersionOrNameLength);
            }

            if (whitespaceLength == 0)
            {
                return 0; // We were able to parse [<protocolName>/]<protocolVersion> but it wasn't followed by a WS
            }

            return current;
        }

        object ICloneable.Clone()
        {
            return new ViaHeaderValue(this);
        }

        private static void CheckReceivedBy(string receivedBy)
        {
            if (string.IsNullOrEmpty(receivedBy))
                throw new ArgumentException(nameof(receivedBy));

            // 'receivedBy' can either be a host or a token. Since a token is a valid host, we only verify if the value
            // is a valid host.;
            if (HttpRuleParser.GetHostLength(receivedBy, 0, true) != receivedBy.Length)
            {
                throw new FormatException("net_http_headers_invalid_value");
            }
        }
    }
}
