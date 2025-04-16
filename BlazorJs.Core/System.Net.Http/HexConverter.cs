namespace System.Net.Http
{
    public static partial class HexConverter
    {
        public static char ToCharUpper(int c)
        {
            return (char)(c <= 9 ? '0' + c : 'A' + (c - 10));
        }
    }
}
