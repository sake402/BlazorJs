using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace System
{
    public static partial class SpanExtensions
    {
        public static ReadOnlySpan<char> AsSpan(this string str, int startIndex = 0, int length = -1)
        {
            return new ReadOnlySpan<char>(str?.ToArray(), startIndex, length);
        }

        public static ReadOnlyMemory<char> AsMemory(this string str, int startIndex = 0, int length = -1)
        {
            return new ReadOnlyMemory<char>(str?.ToArray(), startIndex, length);
        }

        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this T[] str, int startIndex = 0, int length = -1)
        {
            return new ReadOnlySpan<T>(str, startIndex, length);
        }

        public static Span<T> AsSpan<T>(this T[] str, int startIndex = 0, int length = -1)
        {
            return new Span<T>(str, startIndex, length);
        }

        public static string AsString(this ReadOnlySpan<char> span)
        {
            StringBuilder builder = new StringBuilder();
            span.ForEach((t, i) =>
            {
                builder.Append(t);
                return true;
            });
            return builder.ToString();
        }

        public static string AsString(this Span<char> span)
        {
            StringBuilder builder = new StringBuilder();
            span.ForEach((t, i) =>
            {
                builder.Append(t);
                return true;
            });
            return builder.ToString();
        }

        static bool IsTrimCandidate(char c, ReadOnlySpan<char>? needle = null)
        {
            if (needle == null)
            {
                return char.IsWhiteSpace(c);
            }
            return needle.Value.IndexOf(c) >= 0;
        }

        public static ReadOnlySpan<char> TrimStart(this ReadOnlySpan<char> span, ReadOnlySpan<char>? needle = null)
        {
            int start = 0;
            while (IsTrimCandidate(span[start], needle) && start < span.Length)
                start++;
            if (span.Length - 1 >= start)
            {
                return span.Slice(start, span.Length - start);
            }
            return ReadOnlySpan<char>.Empty;
        }

        public static ReadOnlySpan<char> TrimStart(this ReadOnlySpan<char> span, string needle = null)
        {
            return span.TrimStart(needle != null ? needle.AsSpan() : (ReadOnlySpan<char>?)null);
        }

        public static ReadOnlySpan<char> TrimEnd(this ReadOnlySpan<char> span, ReadOnlySpan<char>? needle = null)
        {
            int end = span.Length;
            while (IsTrimCandidate(span[end], needle) && end > 0)
                end--;
            if (end >= 0)
            {
                return span.Slice(0, end - 0);
            }
            return ReadOnlySpan<char>.Empty;
        }

        public static ReadOnlySpan<char> TrimEnd(this ReadOnlySpan<char> span, string needle = null)
        {
            return span.TrimEnd(needle != null ? needle.AsSpan() : (ReadOnlySpan<char>?)null);
        }

        public static ReadOnlySpan<char> Trim(this ReadOnlySpan<char> span, ReadOnlySpan<char>? needle = null)
        {
            return span.TrimStart(needle).TrimEnd(needle);
        }

        public static ReadOnlySpan<char> Trim(this ReadOnlySpan<char> span, char c)
        {
            return span.Trim(c.ToString().AsSpan());
        }

        public static ReadOnlyMemory<char> TrimStart(this ReadOnlyMemory<char> memory, ReadOnlySpan<char>? sets = null)
        {
            return new ReadOnlyMemory<char>(memory.Span.TrimStart(sets));
        }

        public static ReadOnlyMemory<char> TrimStart(this ReadOnlyMemory<char> memory, char c)
        {
            return new ReadOnlyMemory<char>(memory.Span.TrimStart(c.ToString().AsSpan()));
        }

        public static ReadOnlyMemory<char> TrimEnd(this ReadOnlyMemory<char> memory, ReadOnlySpan<char>? sets = null)
        {
            return new ReadOnlyMemory<char>(memory.Span.TrimEnd(sets));
        }

        public static ReadOnlyMemory<char> TrimEnd(this ReadOnlyMemory<char> memory, char c)
        {
            return new ReadOnlyMemory<char>(memory.Span.TrimEnd(c.ToString().AsSpan()));
        }

        public static ReadOnlyMemory<char> Trim(this ReadOnlyMemory<char> memory)
        {
            return new ReadOnlyMemory<char>(memory.Span.Trim());
        }

        public static ReadOnlyMemory<char> Trim(this ReadOnlyMemory<char> memory, char c)
        {
            return new ReadOnlyMemory<char>(memory.Span.Trim(c));
        }

        public static int IndexOf(this ReadOnlySpan<char> span, string sequence)
        {
            int index = -1;
            int seq_i = 0;
            span.ForEach((t, i) =>
            {
                if (sequence[seq_i].Equals(t))
                {
                    if (index == -1)
                        index = i;
                    seq_i++;
                    if (seq_i >= sequence.Length)
                        return false;
                }
                else
                {
                    index = -1;
                    seq_i = 0;
                }
                return true;
            });
            return index;
        }

        public static int LastIndexOf(this ReadOnlySpan<char> span, string sequence)
        {
            int index = -1;
            int seq_i = sequence.Length - 1;
            span.ReverseForEach((t, i) =>
            {
                if (sequence[seq_i].Equals(t))
                {
                    if (index == -1)
                        index = i;
                    seq_i--;
                    if (seq_i < 0)
                        return false;
                }
                else
                {
                    index = -1;
                    seq_i = sequence.Length - 1;
                }
                return true;
            });
            return index;
        }

        public static int IndexOfAny(this ReadOnlySpan<char> span, string chars)
        {
            return span.IndexOfAny(chars.ToArray());
        }

        public static int IndexOfAnyExcept(this ReadOnlySpan<char> span, string chars)
        {
            return span.IndexOfAnyExcept(chars.ToArray());
        }

        public static int IndexOfAnyExceptInRange(this ReadOnlySpan<char> span, char start, char end)
        {
            int result = -1;
            span.ForEach((t, i) =>
            {
                bool inRange = t > start && t < end;
                if (!inRange)
                {
                    result = i;
                    return false;
                }
                return true;
            });
            return result;
        }

        public static bool ContainsAnyExceptInRange(this ReadOnlySpan<char> span, char start, char end)
        {
            bool result = false;
            span.ForEach((t, i) =>
            {
                bool inRange = t > start && t < end;
                if (!inRange)
                {
                    result = true;
                    return false;
                }
                return true;
            });
            return result;
        }

        public static bool ContainsAnyExcept(this ReadOnlySpan<char> span, string chars)
        {
            return span.ContainsAnyExcept(chars.ToArray());
        }

        public static bool IsEqual(this ReadOnlySpan<char> span, string other, StringComparison comparison = StringComparison.Ordinal)
        {
            if (span.Length != other.Length)
                return false;
            bool equals = true;
            span.ForEach((t, i) =>
            {
                bool eq = false;
                switch (comparison)
                {
                    default:
                        eq = t == other[i];
                        break;
                    case StringComparison.CurrentCultureIgnoreCase:
                    case StringComparison.InvariantCultureIgnoreCase:
                    case StringComparison.OrdinalIgnoreCase:
                        eq = char.ToLower(t) == char.ToLower(other[i]);
                        break;
                }
                if (eq)
                {
                    return true;
                }
                equals = false;
                return false;
            });
            return equals;
        }

        public static bool StartsWith(this ReadOnlySpan<char> span, string other, StringComparison comparison = StringComparison.Ordinal)
        {
            if (span.Length < other.Length)
                return false;
            bool starts = true;
            other.AsSpan().ForEach((t, i) =>
            {
                bool eq = false;
                switch (comparison)
                {
                    default:
                        eq = t == span[i];
                        break;
                    case StringComparison.CurrentCultureIgnoreCase:
                    case StringComparison.InvariantCultureIgnoreCase:
                    case StringComparison.OrdinalIgnoreCase:
                        eq = char.ToLower(t) == char.ToLower(span[i]);
                        break;
                }
                if (eq)
                {
                    return true;
                }
                starts = false;
                return false;
            });
            return starts;
        }
    }
}
