using System.Security.Claims;

namespace Microsoft.AspNetCore.Authorization
{
    /// <summary>
    /// Encapsulates the result of <see cref="IAuthorizationService.AuthorizeAsync(ClaimsPrincipal, object, IEnumerable{IAuthorizationRequirement})"/>.
    /// </summary>
    public partial class AuthorizationResult
    {
        private static readonly AuthorizationResult _succeededResult = new AuthorizationResult() { Succeeded = true };
        private static readonly AuthorizationResult _failedResult = new AuthorizationResult() { Failure = AuthorizationFailure.ExplicitFail() };

        private AuthorizationResult() { }

        /// <summary>
        /// True if authorization was successful.
        /// </summary>
        public bool Succeeded { get; private set; }

        /// <summary>
        /// Contains information about why authorization failed.
        /// </summary>
        public AuthorizationFailure Failure { get; private set; }

        /// <summary>
        /// Returns a successful result.
        /// </summary>
        /// <returns>A successful result.</returns>
        public static AuthorizationResult Success() => _succeededResult;

        /// <summary>
        /// Creates a failed authorization result.
        /// </summary>
        /// <param name="failure">Contains information about why authorization failed.</param>
        /// <returns>The <see cref="AuthorizationResult"/>.</returns>
        public static AuthorizationResult Failed(AuthorizationFailure failure) => new AuthorizationResult { Failure = failure };

        /// <summary>
        /// Creates a failed authorization result.
        /// </summary>
        /// <returns>The <see cref="AuthorizationResult"/>.</returns>
        public static AuthorizationResult Failed() => _failedResult;
    }
}