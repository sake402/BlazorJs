using System.IO;
using System.Net.Http.Headers;

namespace System
{
    public partial struct Span<T>
    {
        ReadOnlySpan<T> read;
        T[] _t;

        public Span(int length) : this(new T[length], 0, length)
        {
        }

        public Span(T[] t, int offset = 0, int length = -1)
        {
            _t = t;
            read = new ReadOnlySpan<T>(t, offset, length);
        }

        public bool IsEmpty => read.IsEmpty;
        public int Length => read.Length;
        public int Offset => read.Offset;
        public int Count => read.Length;
        public T[] Array => _t;
        public new T this[int index]
        {
            get => _t[index + Offset];
            set => _t[index + Offset] = value;
        }

        public static implicit operator Span<T>(T[] ts)
        {
            return new Span<T>(ts);
        }

        public void ForEach(Func<T, int, bool> iterator)
        {
            read.ForEach(iterator);
        }

        public Span<T> Slice(int start, int length = -1)
        {
            if (length == -1)
            {
                length = Length - (start + Offset);
            }
            return new Span<T>(_t, start + Offset, length);
        }

        public void CopyTo(Span<T> destination) => read.CopyTo(destination);

        public T[] ToArray() => read.ToArray();

        public int CopyFrom(Stream stream)
        {
            var l = Math.Min(Length, stream.Length);
            stream.Read((byte[])(object)_t, Offset, (int)l);
            return (int)l;
        }

        public int CopyFrom(T[] data)
        {
            var l = Math.Min(Length, data.Length);
            for (int i = 0; i < Length; i++)
                _t[i] = data[i];
            return data.Length;
        }

        public Span<T> this[Range index]
        {
            get => Slice(index.Start, index.Length);
        }

        public bool Contains(T t)
        {
            return read.Contains(t);
        }

        public static implicit operator ReadOnlySpan<T>(Span<T> span)
        {
            return span.read;
        }
    }
}
