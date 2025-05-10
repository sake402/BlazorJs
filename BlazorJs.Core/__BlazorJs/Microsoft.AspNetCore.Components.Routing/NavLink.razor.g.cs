using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


namespace Microsoft.AspNetCore.Components.Routing
{
    public partial class NavLink : Microsoft.AspNetCore.Components.ComponentBase
    {
        protected internal override void InjectServices(IServiceProvider provider)
        {
            NavigationManager = provider.GetRequiredService<Microsoft.AspNetCore.Components.NavigationManager>();

        }


        protected internal override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            __frame0.Element("a", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("href", (this["href"]));
                __attribute.Set("class", CssClass);
                __attribute.Set("aria-current", (_isActive?"page":null));
            }, (__frame1, __key1) =>
            {
                __frame1.Content(ChildContent, key: __key1, sequenceNumber: 2080227530);
            }, sequenceNumber: 2080227531);
        }

    }
}

