using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Microsoft.AspNetCore.Authorization
{
    /// <summary>
    /// Implements an <see cref="IAuthorizationHandler"/> and <see cref="IAuthorizationRequirement"/>
    /// which requires the current user name must match the specified value.
    /// </summary>
    public partial class NameAuthorizationRequirement : AuthorizationHandler<NameAuthorizationRequirement>, IAuthorizationRequirement
    {
        /// <summary>
        /// Constructs a new instance of <see cref="NameAuthorizationRequirement"/>.
        /// </summary>
        /// <param name="requiredName">The required name that the current user must have.</param>
        public NameAuthorizationRequirement(string requiredName)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(requiredName);

            RequiredName = requiredName;
        }

        /// <summary>
        /// Gets the required name that the current user must have.
        /// </summary>
        public string RequiredName { get; }

        /// <summary>
        /// Makes a decision if authorization is allowed based on a specific requirement.
        /// </summary>
        /// <param name="context">The authorization context.</param>
        /// <param name="requirement">The requirement to evaluate.</param>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, NameAuthorizationRequirement requirement)
        {
            if (context.User != null)
            {
                var succeed = false;

                foreach (var identity in context.User.Identities)
                {
                    if (string.Equals(identity.Name, requirement.RequiredName, StringComparison.Ordinal))
                    {
                        succeed = true;
                        break;
                    }
                }

                if (succeed)
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{nameof(NameAuthorizationRequirement)}:Requires a user identity with Name equal to {RequiredName}";
        }
    }
}