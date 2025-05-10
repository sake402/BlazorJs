using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components.Rendering;


namespace Microsoft.AspNetCore.Components.Forms
{
    public partial class InputCheckbox : InputBase<bool>
    {

        protected internal override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            Element = __frame0.Element("input", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("type", "checkbox");
                __attribute.Set("@attributes", this.As<IDictionary<string, object>>());
                __attribute.Set("name", NameAttributeValue);
                __attribute.Set("class", CssClass);
                __attribute.Set("checked", BindConverter.FormatValue(CurrentValue));
                __attribute.Set("value", bool.TrueString);
                var bindGetValue1 = CurrentValue;
                __attribute.Set("value", bindGetValue1);
                __attribute.Set("@onchange", EventCallback.Factory.CreateBinder(this, __value => CurrentValue = __value, bindGetValue1));
            }, null, sequenceNumber: 666296656);
        }

    }
}

