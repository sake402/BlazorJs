using System.Diagnostics.CodeAnalysis;

namespace System
{
    public readonly struct Index : IEquatable<Index>
    {
        public Index(int value, bool fromEnd = false)
        {
            Value = value;
            IsFromEnd = fromEnd;
        }

        //
        // Summary:
        //     Gets an System.Index that points beyond the last element.
        //
        // Returns:
        //     An index that points beyond the last element.
        public static Index End { get; } = new Index(-1, true);
        //
        // Summary:
        //     Gets an System.Index that points to the first element of a collection.
        //
        // Returns:
        //     An instance that points to the first element of a collection.
        public static Index Start { get; } = new Index(0, false);
        //
        // Summary:
        //     Gets a value that indicates whether the index is from the start or the end.
        //
        // Returns:
        //     true if the Index is from the end; otherwise, false.
        public bool IsFromEnd { get; }
        //
        // Summary:
        //     Gets the index value.
        //
        // Returns:
        //     The index value.
        public int Value { get; }

        //
        // Summary:
        //     Creates an System.Index from the end of a collection at a specified index position.
        //
        //
        // Parameters:
        //   value:
        //     The index value from the end of a collection.
        //
        // Returns:
        //     The index value.
        public static Index FromEnd(int value) => new Index(value, true);
        //
        // Summary:
        //     Creates an System.Index from the specified index at the start of a collection.
        //
        //
        // Parameters:
        //   value:
        //     The index position from the start of a collection.
        //
        // Returns:
        //     The index value.
        public static Index FromStart(int value) => new Index(value, false);
        //
        // Summary:
        //     Returns a value that indicates whether the current object is equal to another
        //     System.Index object.
        //
        // Parameters:
        //   other:
        //     The object to compare with this instance.
        //
        // Returns:
        //     true if the current Index object is equal to other; false otherwise.
        public bool Equals(Index other) => other.Value == Value && other.IsFromEnd == IsFromEnd;
        //
        // Summary:
        //     Indicates whether the current Index object is equal to a specified object.
        //
        // Parameters:
        //   value:
        //     An object to compare with this instance.
        //
        // Returns:
        //     true if value is of type System.Index and is equal to the current instance; false
        //     otherwise.
        public override bool Equals([NotNullWhen(true)] object value)
        {
            if (value is Index other)
                return Equals(other);
            return false;
        }
        //
        // Summary:
        //     Returns the hash code for this instance.
        //
        // Returns:
        //     The hash code.
        public override int GetHashCode()
        {
            return HashCode.Combine(Value, IsFromEnd);
        }
        //
        // Summary:
        //     Calculates the offset from the start of the collection using the specified collection
        //     length.
        //
        // Parameters:
        //   length:
        //     The length of the collection that the Index will be used with. Must be a positive
        //     value.
        //
        // Returns:
        //     The offset.
        public int GetOffset(int length)
        {
            if (IsFromEnd)
            {
                return length - 1 - Value;
            }
            return Value;
        }
        //
        // Summary:
        //     Returns the string representation of the current System.Index instance.
        //
        // Returns:
        //     The string representation of the System.Index.
        public override string ToString()
        {
            return Value.ToString();
        }

        //
        // Summary:
        //     Converts an integer number to an System.Index.
        //
        // Parameters:
        //   value:
        //     The integer to convert.
        //
        // Returns:
        //     An index representing the integer.
        public static implicit operator Index(int value) => new Index(value, value < 0);
        public static implicit operator int(Index value) => value.Value;
    }
}
