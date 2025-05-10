using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Microsoft.AspNetCore.Components.Authorization
{
    public partial class AuthorizeViewCore : Microsoft.AspNetCore.Components.ComponentBase
    {
        protected internal override void InjectServices(IServiceProvider provider)
        {
            AuthorizationPolicyProvider = provider.GetRequiredService<Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider>();
            AuthorizationService = provider.GetRequiredService<Microsoft.AspNetCore.Authorization.IAuthorizationService>();

        }

        protected internal override void CascadeParameters()
        {
            RequestCascadingParameter<Task<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>>(e => AuthenticationState = e, cascadingParameterName: null);
            base.CascadeParameters();
        }


    }
}

