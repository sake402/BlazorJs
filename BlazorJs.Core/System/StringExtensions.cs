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

        public static bool StartsWith(this string s, char c)
        {
            return s.StartsWith(c.ToString());
        }
        public static string[] Split(this string s, string c)
        {
            throw new NotImplementedException();
        }
    }
}
