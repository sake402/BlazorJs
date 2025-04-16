using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System
{
    public partial struct Range : IEquatable<Range>
    {
        //
        // Summary:
        //     Instantiates a new System.Range instance with the specified starting and ending
        //     indexes.
        //
        // Parameters:
        //   start:
        //     The inclusive start index of the range.
        //
        //   end:
        //     The exclusive end index of the range.
        public Range(Index start, Index end)
        {
            Start = start;
            End = end;
        }

        //
        // Summary:
        //     Gets a System.Range object that starts from the first element to the end.
        //
        // Returns:
        //     A range from the start to the end.
        public static Range All { get; } = new Range(0, -1);
        //
        // Summary:
        //     Gets an System.Index that represents the exclusive end index of the range.
        //
        // Returns:
        //     The end index of the range.
        public Index End { get; }
        //
        // Summary:
        //     Gets the inclusive start index of the System.Range.
        //
        // Returns:
        //     The inclusive start index of the range.
        public Index Start { get; }

        //
        // Summary:
        //     Creates a System.Range object starting from the first element in the collection
        //     to a specified end index.
        //
        // Parameters:
        //   end:
        //     The position of the last element up to which the System.Range object will be
        //     created.
        //
        // Returns:
        //     A range that starts from the first element to end.
        public static Range EndAt(Index end) => new Range(0, end);
        //
        // Summary:
        //     Returns a new System.Range instance starting from a specified start index to
        //     the end of the collection.
        //
        // Parameters:
        //   start:
        //     The position of the first element from which the Range will be created.
        //
        // Returns:
        //     A range from start to the end of the collection.
        public static Range StartAt(Index start) => new Range(start, -1);
        //
        // Summary:
        //     Returns a value that indicates whether the current instance is equal to a specified
        //     object.
        //
        // Parameters:
        //   value:
        //     An object to compare with this Range object.
        //
        // Returns:
        //     true if value is of type System.Range and is equal to the current instance; otherwise,
        //     false.
        public override bool Equals([NotNullWhen(true)] object value)
        {
            if (value is Range other)
                return Equals(other);
            return false;
        }
        //
        // Summary:
        //     Returns a value that indicates whether the current instance is equal to another
        //     System.Range object.
        //
        // Parameters:
        //   other:
        //     A Range object to compare with this Range object.
        //
        // Returns:
        //     true if the current instance is equal to other; otherwise, false.
        public bool Equals(Range other)
        {
            return Start.Equals(other.Start) && End.Equals(other.End);
        }
        //
        // Summary:
        //     Returns the hash code for this instance.
        //
        // Returns:
        //     The hash code.
        public override int GetHashCode()
        {
            return HashCode.Combine(Start, End);
        }
        //
        // Summary:
        //     Calculates the start offset and length of the range object using a collection
        //     length.
        //
        // Parameters:
        //   length:
        //     A positive integer that represents the length of the collection that the range
        //     will be used with.
        //
        // Returns:
        //     The start offset and length of the range.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     length is outside the bounds of the current range.
        //[return: TupleElementNames(new[] { "Offset", "Length" })]
        public (int Offset, int Length) GetOffsetAndLength(int length)
        {
            var startOffset = Start.GetOffset(length);
            return (startOffset, length/*TODO*/);
        }
        //
        // Summary:
        //     Returns the string representation of the current System.Range object.
        //
        // Returns:
        //     The string representation of the range.
        public override string ToString()
        {
            return Start.ToString() + " to " + End.ToString();
        }
        //public Range()
        //{
        //    Start = -1;
        //    End = -1;
        //}

        //public Range(int start, int end)
        //{
        //    if (end >= start)
        //    {
        //        Start = start;
        //        End = end;
        //    }
        //    else
        //    {
        //        Start = end;
        //        End = start;
        //    }
        //}

        //public int Start { get; set; }
        //public int End { get; set; }
        public int Length => End - Start + 1;
    }
}
