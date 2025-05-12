using System;
using System.Collections.Generic;
using System.Text;

namespace System.Collections.Concurrent
{
    public class ConcurrentDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public ConcurrentDictionary()
        {
        }

        public ConcurrentDictionary(int capacity) : base(capacity)
        {
        }
        
        public TValue GetOrAdd(TKey key, Func<TKey, TValue> create)
        {
            if (TryGetValue(key, out var value))
                return value;
            value = create(key);
            this[key] = value;
            return value;
        }

        public TValue GetOrAdd<T>(TKey key, Func<TKey, T, TValue> create, T t)
        {
            if (TryGetValue(key, out var value))
                return value;
            value = create(key, t);
            this[key] = value;
            return value;
        }

        public bool TryRemove(TKey key, out TValue value)
        {
            if (TryGetValue(key, out value))
            {
                return true;
            }
            value = default;
            return false;
        }
    }
}
