using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Microsoft.AspNetCore.Components.Authorization
{
    public partial class AuthorizeRouteView : Microsoft.AspNetCore.Components.RouteView
    {
        protected internal override void CascadeParameters()
        {
            RequestCascadingParameter<System.Threading.Tasks.Task<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>>(e => ExistingCascadedAuthenticationState = e, cascadingParameterName: null);
            base.CascadeParameters();
        }


    }
}

