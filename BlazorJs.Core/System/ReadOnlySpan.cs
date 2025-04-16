using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace System
{
    public partial struct ReadOnlySpan<T> : IEnumerable<T>
    {
        T[] _t;
        int _offset;
        int _length;

        public static readonly ReadOnlySpan<T> Empty = default;
        public ReadOnlySpan(T[] t, int offset = 0, int length = -1)
        {
            _t = t;
            _offset = offset;
            if (length == -1)
            {
                if (t != null)
                    length = t.Length - offset;
                else length = 0;
            }
            _length = length;
        }

        public int Offset => _offset;
        public bool IsEmpty => _length == 0;
        public int Length => _length;

        public T this[int index]
        {
            get => _t[index + _offset];
        }

        public void ForEach(Func<T, int, bool> iterator)
        {
            for (int i = 0; i < Length; i++)
            {
                if (iterator(this[i], i) == false)
                    break;
            }
        }

        public void ReverseForEach(Func<T, int, bool> iterator)
        {
            for (int i = Length - 1; i >= 0; i--)
            {
                if (iterator(this[i], i) == false)
                    break;
            }
        }

        public ReadOnlySpan<T> this[Range index]
        {
            get => Slice(index.Start, index.Length);
        }

        public ReadOnlySpan<T> Slice(int start, int length = -1)
        {
            if (length == -1)
            {
                length = _length - (start + _offset);
            }
            return new ReadOnlySpan<T>(_t, start + _offset, length);
        }

        public void CopyTo(Span<T> destination)
        {
            ForEach((t, i) =>
            {
                destination[i] = t;
                return true;
            });
        }

        public void CopyTo(Stream destination)
        {
            destination.Write((byte[])(object)_t, _offset, _length);
        }

        public T[] ToArray()
        {
            var newT = new T[Length];
            ForEach((t, i) =>
            {
                newT[i] = t;
                return true;
            });
            return newT;
        }

        public bool Contains(T c)
        {
            bool result = false;
            ForEach((t, i) =>
            {
                if (c.Equals(t))
                {
                    result = true;
                    return false;
                }
                return true;
            });
            return result;
        }

        public bool ContainsAny(params T[] chars)
        {
            bool result = false;
            ForEach((t, i) =>
            {
                if (chars.Any(c => c.Equals(t)))
                {
                    result = true;
                    return false;
                }
                return true;
            });
            return result;
        }

        public bool ContainsAnyExcept(params T[] chars)
        {
            bool result = false;
            ForEach((t, i) =>
            {
                if (!chars.Any(c => c.Equals(t)))
                {
                    result = true;
                    return false;
                }
                return true;
            });
            return result;
        }

        public int IndexOf(T c)
        {
            int index = -1;
            ForEach((t, i) =>
            {
                if (c.Equals(t))
                {
                    index = i;
                    return false;
                }
                return true;
            });
            return index;
        }

        public int LastIndexOf(T c)
        {
            int index = -1;
            ReverseForEach((t, i) =>
            {
                if (c.Equals(t))
                {
                    index = i;
                    return false;
                }
                return true;
            });
            return index;
        }

        public int IndexOfAny(params T[] chars)
        {
            int index = -1;
            ForEach((t, i) =>
            {
                if (chars.Any(c => c.Equals(t)))
                {
                    index = i;
                    return false;
                }
                return true;
            });
            return index;
        }

        public int IndexOfAnyExcept(params T[] chars)
        {
            int index = -1;
            ForEach((t, i) =>
            {
                if (!chars.Any(c => c.Equals(t)))
                {
                    index = i;
                    return false;
                }
                return true;
            });
            return index;
        }

        public bool StartsWith(T needle)
        {
            return _length > 0 && this[0].Equals(needle);
        }

        public bool StartsWith(ReadOnlySpan<T> other)
        {
            if (Length < other.Length)
                return false;
            bool starts = true;
            var me = this;
            other.ForEach((t, i) =>
            {
                bool eq = t.Equals(me[i]);
                if (eq)
                {
                    return true;
                }
                starts = false;
                return false;
            });
            return starts;
        }

        public int Split(Span<Range> ranges, T delimiter)
        {
            int r_i = 0;
            int start = 0;
            ForEach((t, i) =>
            {
                if (delimiter.Equals(t))
                {
                    ranges[r_i++] = new Range(start, i - 1);
                    start = i + 1;
                }
                return true;
            });
            if (start > 0)
            {
                ranges[r_i++] = new Range(start, Length - 1);
            }
            return r_i;
        }

        public static implicit operator ReadOnlySpan<T>(T[] ts)
        {
            return new ReadOnlySpan<T>(ts);
        }

        public static implicit operator string(ReadOnlySpan<T> span)
        {
            return span.ToString();
        }

        public override string ToString()
        {
            if (typeof(T) == typeof(char))
                return ((ReadOnlySpan<char>)(object)this).AsString();
            return base.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ReadOnlySpanEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ReadOnlySpanEnumerator(this);
        }

        partial class ReadOnlySpanEnumerator : IEnumerator<T>
        {
            ReadOnlySpan<T> span;
            int index = -1;
            public ReadOnlySpanEnumerator(ReadOnlySpan<T> span)
            {
                this.span = span;
            }

            public T Current => span[index];
            object IEnumerator.Current => span[index];

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                index++;
                return index < span.Length;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }
}
