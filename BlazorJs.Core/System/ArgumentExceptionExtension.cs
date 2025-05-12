namespace System
{
    public static partial class ArgumentExceptionExtension
    {
        public static void ThrowIfNullOrEmpty(string o)
        {
            if (string.IsNullOrEmpty(o))
                throw new NullReferenceException();
        }

        public static void ThrowIfNullOrWhiteSpace(string o)
        {
            if (string.IsNullOrWhiteSpace(o))
                throw new NullReferenceException();
        }
    }
}
