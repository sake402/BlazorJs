using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components.Rendering;


namespace Microsoft.AspNetCore.Components.Forms
{
    public partial class InputText : InputBase<string>
    {

        protected internal override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            Element = __frame0.Element("input", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("@attributes", (this.As<IReadOnlyDictionary<string, object>>()));
                __attribute.Set("name", NameAttributeValue);
                __attribute.Set("class", CssClass);
                var bindGetValue1 = @CurrentValueAsString;
                __attribute.Set("value", bindGetValue1);
                __attribute.Set("@onchange", EventCallback.Factory.CreateBinder(this, __value => @CurrentValueAsString = __value, bindGetValue1));
            }, null, sequenceNumber: -1953795527);
        }

    }
}

