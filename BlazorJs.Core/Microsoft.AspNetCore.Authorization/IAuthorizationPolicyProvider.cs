using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Authorization
{
    public partial interface IAuthorizationPolicyProvider
    {
        /// <summary>
        /// Gets a <see cref="AuthorizationPolicy"/> from the given <paramref name="policyName"/>
        /// </summary>
        /// <param name="policyName">The policy name to retrieve.</param>
        /// <returns>The named <see cref="AuthorizationPolicy"/>.</returns>
        Task<AuthorizationPolicy> GetPolicyAsync(string policyName);

        /// <summary>
        /// Gets the default authorization policy.
        /// </summary>
        /// <returns>The default authorization policy.</returns>
        Task<AuthorizationPolicy> GetDefaultPolicyAsync();

        /// <summary>
        /// Gets the fallback authorization policy.
        /// </summary>
        /// <returns>The fallback authorization policy.</returns>
        Task<AuthorizationPolicy> GetFallbackPolicyAsync();

#if NETCOREAPP
    /// <summary>
    /// Determines if policies from this provider can be cached, defaults to false.
    /// </summary>
    bool AllowsCachingPolicies => false;
#endif
    }
}