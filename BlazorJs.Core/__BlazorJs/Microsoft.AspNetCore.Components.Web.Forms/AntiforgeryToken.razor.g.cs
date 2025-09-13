using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;


namespace Microsoft.AspNetCore.Components.Forms
{
    public partial class AntiforgeryToken : Microsoft.AspNetCore.Components.ComponentBase
    {
        protected internal override void InjectServices(IServiceProvider provider)
        {
            Services = provider.GetRequiredService<System.IServiceProvider>();

        }


        protected internal override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            if (_requestToken != null)
            {
                __frame0.Element("input", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("type", "hidden");
                    __attribute.Set("name", _requestToken.FormFieldName);
                    __attribute.Set("value", _requestToken.Value);
                }, null, sequenceNumber: -826633741);
            }
        }

    }
}

