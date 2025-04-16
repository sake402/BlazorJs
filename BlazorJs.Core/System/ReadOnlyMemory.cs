namespace System
{
    public partial struct ReadOnlyMemory<T>
    {
        public static readonly ReadOnlySpan<T> Empty = default;
        ReadOnlySpan<T> _span;
        public ReadOnlyMemory(T[] t, int offset = 0, int length = -1)
        {
            _span = new ReadOnlySpan<T>(t, offset, length);
        }
        internal ReadOnlyMemory(ReadOnlySpan<T> span)
        {
            this._span = span;
        }
        public ReadOnlySpan<T> Span => _span;
        public int Length => _span.Length;
        public ReadOnlyMemory<T> Slice(int start, int length = -1) => new ReadOnlyMemory<T>(_span.Slice(start, length));
        //public ReadOnlyMemory<T> Trim() => new ReadOnlyMemory<T>(_span.Tri(start, length));
    }
}
