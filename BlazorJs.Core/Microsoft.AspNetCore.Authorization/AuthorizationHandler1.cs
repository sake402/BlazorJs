using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Microsoft.AspNetCore.Authorization
{
    /// <summary>
    /// Base class for authorization handlers that need to be called for specific requirement and
    /// resource types.
    /// </summary>
    /// <typeparam name="TRequirement">The type of the requirement to evaluate.</typeparam>
    /// <typeparam name="TResource">The type of the resource to evaluate.</typeparam>
    public abstract partial class AuthorizationHandler<TRequirement, TResource> : IAuthorizationHandler
        where TRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// Makes a decision if authorization is allowed.
        /// </summary>
        /// <param name="context">The authorization context.</param>
        public virtual async Task HandleAsync(AuthorizationHandlerContext context)
        {
            if (context.Resource is TResource resource)
            {
                foreach (var req in context.Requirements.OfType<TRequirement>())
                {
                    await HandleRequirementAsync(context, req, resource);
                }
            }
        }

        /// <summary>
        /// Makes a decision if authorization is allowed based on a specific requirement and resource.
        /// </summary>
        /// <param name="context">The authorization context.</param>
        /// <param name="requirement">The requirement to evaluate.</param>
        /// <param name="resource">The resource to evaluate.</param>
        protected abstract Task HandleRequirementAsync(AuthorizationHandlerContext context, TRequirement requirement, TResource resource);
    }
}