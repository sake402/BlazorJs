using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace System.Net.Http
{

    public static partial class Ascii
    {
        public static bool IsValid(string str)
        {
            return str.All(c => c < 128);
        }

        public static bool EqualsIgnoreCase(ReadOnlySpan<byte> name, string str)
        {
            if (name.Length != str.Length)
                return false;
            bool equals = true;
            name.ForEach((t, i) =>
            {
                bool eq = t == str[i];
                if (!eq)
                {
                    equals = false;
                    return false;
                }
                return true;
            });
            return equals;
        }
    }
}
