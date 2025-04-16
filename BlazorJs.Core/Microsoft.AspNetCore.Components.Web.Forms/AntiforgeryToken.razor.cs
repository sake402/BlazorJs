// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Components.Rendering;
using System;

namespace Microsoft.AspNetCore.Components.Forms
{

    /// <summary>
    /// Component that renders an antiforgery token as a hidden field.
    /// </summary>
    public partial class AntiforgeryToken : ComponentBase
    {
        private bool _hasRendered;
        private AntiforgeryRequestToken _requestToken;

        [Inject] IServiceProvider Services { get; set; }

        protected internal override void OnInitialized()
        {
            _requestToken = Services.GetService<AntiforgeryStateProvider>()?.GetAntiforgeryToken();
            base.OnInitialized();
        }

    }
}