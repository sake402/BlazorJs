using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms.Mapping;
using Microsoft.AspNetCore.Components.Rendering;


namespace Microsoft.AspNetCore.Components.Forms
{
    public partial class EditForm : Microsoft.AspNetCore.Components.ComponentBase
    {
        protected internal override void CascadeParameters()
        {
            RequestCascadingParameter<Microsoft.AspNetCore.Components.Forms.FormMappingContext>(e => MappingContext = e, cascadingParameterName: null);
            base.CascadeParameters();
        }


        protected internal override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            __frame0.Element("form", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("method", (MappingContext != null?"post":null));
                __attribute.Set("data-enhance", (Enhance?"":null));
                __attribute.Set("@attributes", (this.As<IReadOnlyDictionary<string, object>>()));
                __attribute.Set("@onsubmit", EventCallback.Factory.Create(this, _handleSubmitDelegate));
            }, null, key: _editContext.GetHashCode(), sequenceNumber: -808443956);
            __frame0.Component<CascadingValue<EditContext>>((__component0) =>
            {
                __component0.IsFixed = true;
                __component0.Value = _editContext;
                __component0.ChildContent = (__frame1, __key1) =>
                {
                    __frame1.Content(ChildContent?.Invoke(_editContext), key: __key1, sequenceNumber: -808443955);
                };
            }, sequenceNumber: -808443954);
        }

    }
}

