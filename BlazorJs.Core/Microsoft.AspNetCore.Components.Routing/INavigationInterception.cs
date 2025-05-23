// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Components.Routing
{

    /// <summary>
    /// Contract to setup navigation interception on the client.
    /// </summary>
    public partial interface INavigationInterception
    {
        /// <summary>
        /// Enables navigation interception on the client.
        /// </summary>
        /// <returns>A <see cref="Task" /> that represents the asynchronous operation.</returns>
        Task EnableNavigationInterceptionAsync();
    }
}
