namespace System
{
    public static partial class ArgumentExceptionExtension
    {
        public static void ThrowIfNullOrEmpty(string o)
        {
            if (string.IsNullOrEmpty(o))
                throw new NullReferenceException();
        }
    }
}
