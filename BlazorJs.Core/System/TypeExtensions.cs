using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace System
{
    public static partial class TypeExtensions
    {
        public static Type[] FindInterfaces(this Type type, TypeFilter filter, object filterCriteria)
        {
            return type.GetInterfaces().Where(t => filter(t, filterCriteria)).ToArray();
        }

        public static IEnumerable<PropertyInfo> GetRuntimeProperties(this Type type)
        {
            return type.GetProperties();
        }

        public static T GetCustomAttribute<T>(this Type type, bool inherit = false)
        {
            return type.GetCustomAttributes(typeof(T), inherit).SingleOrDefault().As<T>();
        }

        public static T GetCustomAttribute<T>(this MemberInfo type, bool inherit = false)
        {
            return type.GetCustomAttributes(typeof(T), inherit).SingleOrDefault().As<T>();
        }

        public static bool IsDefined<T>(this Type type)
        {
            return type.GetCustomAttributes(typeof(T), true).Any();
        }

        public static bool IsDefined(this Type type, Type attributeType)
        {
            return type.GetCustomAttributes(attributeType, true).Any();
        }

        public static Type MakeGenericType(this Type type, Type gType)
        {
            return type.MakeGenericType(new[] { gType });
        }

        public static Type MakeGenericType(this Type type, Type gType1, Type gType2)
        {
            return type.MakeGenericType(new[] { gType1, gType2 });
        }

        public static Type MakeGenericType(this Type type, Type gType1, Type gType2, Type gType3)
        {
            return type.MakeGenericType(new[] { gType1, gType2, gType3 });
        }
    }
}
