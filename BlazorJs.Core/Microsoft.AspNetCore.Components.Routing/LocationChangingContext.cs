// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using System.Threading;

namespace Microsoft.AspNetCore.Components.Routing
{

    /// <summary>
    /// Contains context for a change to the browser's current location.
    /// </summary>
    public sealed partial class LocationChangingContext
    {
        internal bool DidPreventNavigation { get; private set; }

        /// <summary>
        /// Gets the target location.
        /// </summary>
        public string TargetLocation { get; set; }

        /// <summary>
        /// Gets the state associated with the target history entry.
        /// </summary>
        public object HistoryEntryState { get; set; }

        /// <summary>
        /// Gets whether this navigation was intercepted from a link.
        /// </summary>
        public bool IsNavigationIntercepted { get; set; }

        /// <summary>
        /// Gets a <see cref="System.Threading.CancellationToken"/> that can be used to determine if this navigation was canceled
        /// (for example, because the user has triggered a different navigation).
        /// </summary>
        public CancellationToken CancellationToken { get; set; }

        /// <summary>
        /// Prevents this navigation from continuing.
        /// </summary>
        public void PreventNavigation()
        {
            DidPreventNavigation = true;
        }
    }
}