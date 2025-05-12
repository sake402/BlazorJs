using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace System.Reflection
{
    public static class AttributeExtension
    {
        public static IEnumerable<T> GetCustomAttributes<T>(this Type t, bool inherit)
        {
            return Enumerable.Cast<T>(t.GetCustomAttributes(typeof(T), inherit));
        }

        public static IEnumerable<T> GetCustomAttributes<T>(this MethodInfo t, bool inherit)
        {
            return Enumerable.Cast<T>(t.GetCustomAttributes(typeof(T), inherit));
        }
    }
}
