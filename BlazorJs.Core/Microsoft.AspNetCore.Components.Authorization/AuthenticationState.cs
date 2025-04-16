// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Security.Claims;
using System;

namespace Microsoft.AspNetCore.Components.Authorization
{
    /// <summary>
    /// Provides information about the currently authenticated user, if any.
    /// </summary>
    public partial class AuthenticationState
    {
        /// <summary>
        /// Constructs an instance of <see cref="AuthenticationState"/>.
        /// </summary>
        /// <param name="user">A <see cref="ClaimsPrincipal"/> representing the user.</param>
        public AuthenticationState(ClaimsPrincipal user)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(user);
            User = user;
        }

        /// <summary>
        /// Gets a <see cref="ClaimsPrincipal"/> that describes the current user.
        /// </summary>
        public ClaimsPrincipal User { get; }
    }
}