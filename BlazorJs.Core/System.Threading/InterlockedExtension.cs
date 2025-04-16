using System;
using System.Collections.Generic;
using System.Text;

namespace System.Threading
{
    public static partial class InterlockedExtension
    {
        public static int CompareExchange(ref int location1, int value, int comparand)
        {
            var old = location1;
            if (location1 == comparand)
            {
                location1 = value;
            }
            return old;
        }

        public static T CompareExchange<T>(ref T location1, T value, T comparand) where T : class
        {
            var old = location1;
            if (location1.Equals(comparand))
            {
                location1 = value;
            }
            return old;
        }
    }
}
