using System;
using System.Collections.Generic;
using System.Text;

namespace System.Collections.Generic
{
    public static partial class DictionaryExtension
    {
        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> createValue)
        {
            if (dictionary.TryGetValue(key, out var value))
                return value;
            value = createValue(key);
            dictionary[key] = value;
            return value;
        }
    }
}
