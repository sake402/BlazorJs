using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Components.Rendering;


namespace Microsoft.AspNetCore.Components.Routing
{
    public partial class Router : Microsoft.AspNetCore.Components.ComponentBase
    {
        protected internal override void InjectServices(IServiceProvider provider)
        {
            NavigationManager = provider.GetRequiredService<Microsoft.AspNetCore.Components.NavigationManager>();
            NavigationInterception = provider.GetRequiredService<Microsoft.AspNetCore.Components.Routing.INavigationInterception>();
            ScrollToLocationHash = provider.GetService<Microsoft.AspNetCore.Components.Routing.IScrollToLocationHash>();
            ServiceProvider = provider.GetRequiredService<System.IServiceProvider>();

        }


    }
}

