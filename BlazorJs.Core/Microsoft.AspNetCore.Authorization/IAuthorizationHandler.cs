using System;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Authorization
{
    /// <summary>
    /// Classes implementing this interface are able to make a decision if authorization is allowed.
    /// </summary>
    public partial interface IAuthorizationHandler
    {
        /// <summary>
        /// Makes a decision if authorization is allowed.
        /// </summary>
        /// <param name="context">The authorization information.</param>
        Task HandleAsync(AuthorizationHandlerContext context);
    }
}