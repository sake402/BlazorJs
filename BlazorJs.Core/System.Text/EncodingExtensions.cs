using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text
{
    public partial class Decoder
    {
        Encoding encoding;

        public Decoder(Encoding encoding)
        {
            this.encoding = encoding;
        }

        public virtual void Convert(
            byte[] inBytes, int byteIndex, int byteCount,
            char[] outChars, int charIndex, int charCount, bool flush,
            out int bytesUsed, out int charsUsed, out bool completed)
        {
            throw new NotImplementedException();
        }
    }
    public partial class Encoder
    {
        Encoding encoding;

        public Encoder(Encoding encoding)
        {
            this.encoding = encoding;
        }

        public void Convert(
            char[] inChars, int charIndex, int charCount,
            byte[] outBytes, int byteIndex, int byteCount, bool flush,
            out int charsUsed, out int bytesUsed, out bool completed)
        {
            throw new NotImplementedException();
            //charsUsed=charCount;
            //var str = new string(inChars, charIndex, charCount);
            //((dynamic)encoding).Encode(str, outBytes, byteIndex, out bytesUsed);
        }
    }
    public static partial class EncodingExtensions
    {
        public static Encoder GetEncoder(this Encoding encoding)
        {
            return new Encoder(encoding);
        }

        public static Decoder GetDecoder(this Encoding encoding)
        {
            return new Decoder(encoding);
        }
    }
}
