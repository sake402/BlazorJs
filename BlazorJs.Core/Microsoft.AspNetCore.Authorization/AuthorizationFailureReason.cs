namespace Microsoft.AspNetCore.Authorization
{
    /// <summary>
    /// Encapsulates a reason why authorization failed.
    /// </summary>
    public partial class AuthorizationFailureReason
    {
        /// <summary>
        /// Creates a new failure reason.
        /// </summary>
        /// <param name="handler">The handler responsible for this failure reason.</param>
        /// <param name="message">The message describing the failure.</param>
        public AuthorizationFailureReason(IAuthorizationHandler handler, string message)
        {
            Handler = handler;
            Message = message;
        }

        /// <summary>
        /// A message describing the failure reason.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// The <see cref="IAuthorizationHandler"/> responsible for this failure reason.
        /// </summary>
        public IAuthorizationHandler Handler { get; }
    }
}