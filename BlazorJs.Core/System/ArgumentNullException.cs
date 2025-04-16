using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static partial class ArgumentNullExceptionExtension
    {
        public static void ThrowIfNull(object o, string name = null)
        {
            if (o == null)
                throw new NullReferenceException();
        }
    }
}
