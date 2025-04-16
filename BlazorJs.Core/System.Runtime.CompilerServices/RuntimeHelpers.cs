using System;
using System.Collections.Generic;
using System.Text;

namespace System.Runtime.CompilerServices
{
    //    public static partial class RuntimeHelpers
    //{
    //    public static int GetHashCode(object t)
    //    {
    //        return t?.GetHashCode() ?? 0;
    //    }
    //}

}

namespace Microsoft.AspNetCore.Components.CompilerServices
{
    //make razor generator happy
    public static partial class RuntimeHelpers
    {
        public static T TypeCheck<T>(T t) { return t; }
    }
}
