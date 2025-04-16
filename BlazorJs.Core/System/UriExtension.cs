using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public enum UriKind
    {
        RelativeOrAbsolute
    }
    public static partial class UriExtension
    {
        public static bool IsAbsoluteUri(this Uri uri)
        {
            return uri.AbsoluteUri.StartsWith("http");
        }

        public static string OriginalString(this Uri uri)
        {
            return uri.ToString();
        }

        public static bool TryCreate(this string uriString, UriKind uriKind, out Uri uri)
        {
            try
            {
                uri = new Uri(uriString);
            }
            catch
            {
                uri = null;
                return false;
            }
            return true;
        }

        public static bool IsHex(char c)
        {
            return (c >= '0' && c <= '9') || (c >= 'A' && c <= 'f') || (c >= 'a' && c <= 'f');
        }

        public static byte Nibble(char c)
        {
            return (c >= '0' && c <= '9') ? (byte)(c - '0') : (c >= 'A' && c <= 'f') ? (byte)(c - 'A' + 10) : (c >= 'a' && c <= 'f') ? (byte)(c - 'a' + 10) : throw new InvalidOperationException($"invalid hex character {c}");
        }

        public static bool IsHexEncoding(string dataString, int index)
        {
            return dataString[index] == '%' && IsHex(dataString[index + 1]) && IsHex(dataString[index + 1]);
        }

        public static int HexUnescape(string dataString, ref int index)
        {
            index = index + 1;
            int result = 0;
            while (IsHex(dataString[index]))
            {
                result <<= 4;
                result |= Nibble(dataString[index]);
                index++;
            }
            return result;
        }

        public static char Hex2Char(char upper, char lower)
        {
            return (char)((Nibble(upper) << 4) | Nibble(lower));
        }

        public static void Decode(char[] source, char[] destination, out int writtenLength)
        {
            int iSource = 0;
            int iDestination = 0;
            while (iSource < source.Length)
            {
                if (source[iSource] == '%' && iSource + 2 < source.Length && IsHex(source[iSource + 1]) && IsHex(source[iSource + 2]))
                {
                    destination[iDestination++] = Hex2Char(source[iSource + 1], source[iSource + 2]);
                    iSource += 3;
                }
                else
                {
                    destination[iDestination++] = source[iSource];
                    iSource++;
                }
            }
            writtenLength = iDestination;
        }
    }
}
