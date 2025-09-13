using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Microsoft.AspNetCore.Components.Authorization
{
    public partial class CascadingAuthenticationState : Microsoft.AspNetCore.Components.ComponentBase
    {
        protected internal override void InjectServices(IServiceProvider provider)
        {
            AuthenticationStateProvider = provider.GetRequiredService<Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider>();

        }


        protected internal override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            __frame0.Component<CascadingValue<System.Threading.Tasks.Task<AuthenticationState>>>((__component0) =>
            {
                __component0.Value = _currentAuthenticationStateTask;
                __component0.ChildContent = ChildContent;
            }, sequenceNumber: -617868881);
        }

    }
}

