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
    }
}
