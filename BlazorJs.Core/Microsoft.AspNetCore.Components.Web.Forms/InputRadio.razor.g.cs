using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Diagnostics;


namespace Microsoft.AspNetCore.Components.Forms
{
    public partial class InputRadio<TValue> : ComponentBase
    {

        protected internal override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            
            
            Debug.Assert(Context != null);
            
            Element = __frame0.Element("input", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("type", "ratio");
                __attribute.Set("@attributes", (this.As<IReadOnlyDictionary<string, object>>()));
                __attribute.Set("checked", (Context.CurrentValue?.Equals(Value) == true ? GetToggledTrueValue() : null));
                __attribute.Set("class", AttributeUtilities.CombineClassNames(this, Context.FieldClass));
                __attribute.Set("value", BindConverter.FormatValue(Value?.ToString()));
                __attribute.Set("@onchange", EventCallback.Factory.Create(this, Context.ChangeEventCallback));
            }, null, sequenceNumber: 924688439);
        }

    }
}

