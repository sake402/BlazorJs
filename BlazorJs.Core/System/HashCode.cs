using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public partial class HashCode
    {
        int code = 897534562;
        public void Add(object c)
        {
            var cc = c.GetHashCode();
            code ^= cc;
        }

        public int ToHashCode()
        {
            return code;
        }

        public static int Combine<T1, T2>(T1 t1, T2 t2)
        {
            HashCode hc = new HashCode();
            hc.Add(t1);
            hc.Add(t2);
            return hc.ToHashCode();
        }
        public static int Combine<T1, T2, T3>(T1 t1, T2 t2, T3 t3)
        {
            HashCode hc = new HashCode();
            hc.Add(t1);
            hc.Add(t2);
            hc.Add(t3);
            return hc.ToHashCode();
        }
        public static int Combine<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            HashCode hc = new HashCode();
            hc.Add(t1);
            hc.Add(t2);
            hc.Add(t3);
            hc.Add(t4);
            return hc.ToHashCode();
        }
        public static int Combine<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            HashCode hc = new HashCode();
            hc.Add(t1);
            hc.Add(t2);
            hc.Add(t3);
            hc.Add(t4);
            hc.Add(t5);
            return hc.ToHashCode();
        }
        public static int Combine<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            HashCode hc = new HashCode();
            hc.Add(t1);
            hc.Add(t2);
            hc.Add(t3);
            hc.Add(t4);
            hc.Add(t5);
            hc.Add(t6);
            return hc.ToHashCode();
        }
        public static int Combine<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            HashCode hc = new HashCode();
            hc.Add(t1);
            hc.Add(t2);
            hc.Add(t3);
            hc.Add(t4);
            hc.Add(t5);
            hc.Add(t6);
            hc.Add(t7);
            return hc.ToHashCode();
        }
        public static int Combine<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            HashCode hc = new HashCode();
            hc.Add(t1);
            hc.Add(t2);
            hc.Add(t3);
            hc.Add(t4);
            hc.Add(t5);
            hc.Add(t6);
            hc.Add(t7);
            hc.Add(t8);
            return hc.ToHashCode();
        }
    }
}
