namespace System
{
    public static partial class StringExtensions
    {
        public static bool Contains(this string s, char c)
        {
            return s.Contains(c.ToString());
        }

        public static bool EndsWith(this string s, char c)
        {
            return s.EndsWith(c.ToString());
        }
    }
}
