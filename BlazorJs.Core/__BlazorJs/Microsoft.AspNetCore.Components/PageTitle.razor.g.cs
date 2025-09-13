using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Microsoft.AspNetCore.Components
{
    public partial class PageTitle : Microsoft.AspNetCore.Components.ComponentBase
    {

        protected internal override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            titleWrapper = __frame0.Element("span", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("style", "display:none");
            }, (__frame1, __key1) =>
            {
                __frame1.Content(ChildContent, key: __key1, sequenceNumber: -987110344);
            }, sequenceNumber: -987110343);
        }

    }
}

