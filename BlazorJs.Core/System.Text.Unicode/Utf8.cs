using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Unicode
{
    public static partial class Utf8
    {
        public static OperationStatus ToUtf16(ReadOnlySpan<byte> source, Span<char> destination, out int bytesRead, out int charsWritten, bool replaceInvalidSequences = true, bool isFinalBlock = true)
        {
            throw new NotImplementedException();
        }
    }
}
