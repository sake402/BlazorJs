using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Microsoft.AspNetCore.Components.Rendering;


namespace Microsoft.AspNetCore.Components.Forms
{
    public partial class InputSelect<TValue> : InputBase<TValue>
    {

        protected internal override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            if (_isMultipleSelect)
            {
                Element = __frame0.Element("select", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("@attributes", (this.As<IReadOnlyDictionary<string, object>>()));
                    __attribute.Set("name", NameAttributeValue);
                    __attribute.Set("class", CssClass);
                    __attribute.Set("multiple", _isMultipleSelect);
                    __attribute.Set("value", @BindConverter.FormatValue(CurrentValue)?.ToString());
                    __attribute.Set("@onchange", EventCallback.Factory.CreateBinder(this, (Action<string[]>)SetCurrentValueAsStringArray, default));
                }, null, sequenceNumber: -1976234328);
            }
            else
            {
                Element = __frame0.Element("select", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("@attributes", (this.As<IReadOnlyDictionary<string, object>>()));
                    __attribute.Set("name", NameAttributeValue);
                    __attribute.Set("class", CssClass);
                    __attribute.Set("multiple", _isMultipleSelect);
                    var bindGetValue1 = @CurrentValueAsString;
                    __attribute.Set("value", bindGetValue1);
                    __attribute.Set("@onchange", EventCallback.Factory.CreateBinder(this, __value => @CurrentValueAsString = __value, bindGetValue1));
                }, null, sequenceNumber: -1976234327);
            }
        }

    }
}

