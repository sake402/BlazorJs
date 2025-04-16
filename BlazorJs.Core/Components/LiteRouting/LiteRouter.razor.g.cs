using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System.Collections.Generic;
using System.Text;


namespace BlazorJs.Core.Components.LiteRouting
{
    public partial class LiteRouter : Microsoft.AspNetCore.Components.ComponentBase
    {
        protected internal override void InjectServices(IServiceProvider provider)
        {
            Navigation = provider.GetRequiredService<Microsoft.AspNetCore.Components.NavigationManager>();

        }


        protected internal override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            if (route != null)
            {
                __frame0.Content(Found(), sequenceNumber: 1447695830);
            }
            else
            {
                __frame0.Content(NotFound, sequenceNumber: 1447695831);
            }
        }

    }
}

