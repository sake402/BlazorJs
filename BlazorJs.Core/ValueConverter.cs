using System;
using System.Reflection;

namespace BlazorJs.Core
{
    public static partial class ValueConverter
    { 
        static object converters = new object();
        public static int Convert(object value, int inferType)
        {
            return int.Parse(value.ToString());
        } 
        public static int? Convert(object value, int? inferType)
        {
            if (value == null || value.ToString() == "")
                return null;
            return int.Parse(value.ToString());
        }
        public static double Convert(object value, double inferType)
        {
            return double.Parse(value.ToString());
        }
        public static double? Convert(object value, double? inferType)
        {
            if (value == null || value.ToString() == "")
                return null;
            return double.Parse(value.ToString());
        }
        public static string Convert(object value, string inferType)
        {
            return value.ToString();
        }

        public static object Convert(object value, Type type)
        {
            if (converters.TryGetValue(type.FullName, out var converter))
            {
                return ((Delegate)converter).Call(null, value);
            }
            if (type.IsEnum)
            {
                if (value != null)
                {
                    var i = int.Parse(value.ToString());
                    return i;
                }
                return default;
            }
            if (value is string str)
            {
                if (type == typeof(string))
                    return value;
                MethodInfo method = type.GetMethod("Parse", new[] { typeof(string) });
                if (method != null)
                {
                    return method.Invoke(null, value);
                }
            }
            throw new InvalidOperationException($"No converter is regietered for {type.FullName}");
        }

        public static T Convert<T>(object value, T inferType)
        {
            return (T)Convert(value, typeof(T));
        }

        public static void Register<T>(Func<object, T> converter)
        {
            converters[typeof(T).FullName] = converter;
        }
    }
}
