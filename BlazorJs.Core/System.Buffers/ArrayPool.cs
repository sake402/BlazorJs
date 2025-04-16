using System;
using System.Collections.Generic;
using System.Text;

namespace System.Buffers
{
    public partial class ArrayPool<T>
    {
        public static readonly ArrayPool<T> Shared = new ArrayPool<T>();

        public T[] Rent(int len)
        {
            return new T[len];
        }

        public void Return(T[] t) { }
    }
}
