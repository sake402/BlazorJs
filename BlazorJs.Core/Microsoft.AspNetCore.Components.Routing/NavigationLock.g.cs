using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;


namespace Microsoft.AspNetCore.Components.Routing
{
    public partial class NavigationLock : Microsoft.AspNetCore.Components.ComponentBase
    {
        protected internal override void InjectServices(IServiceProvider provider)
        {
            NavigationManager = provider.GetRequiredService<Microsoft.AspNetCore.Components.NavigationManager>();

        }


    }
}

