using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace Microsoft.AspNetCore.Components
{
    public partial class RouteView : Microsoft.AspNetCore.Components.ComponentBase
    {
        protected internal override void InjectServices(IServiceProvider provider)
        {
            NavigationManager = provider.GetRequiredService<Microsoft.AspNetCore.Components.NavigationManager>();

        }


    }
}

