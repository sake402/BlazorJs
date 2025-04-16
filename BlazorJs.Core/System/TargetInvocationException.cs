namespace System
{
    public class TargetInvocationException : Exception
    {
        public TargetInvocationException()
        {
        }

        public TargetInvocationException(string message) : base(message)
        {
        }

        public TargetInvocationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
