using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components.Rendering;


namespace Microsoft.AspNetCore.Components.Forms
{
    public partial class ValidationMessage<TValue> : Microsoft.AspNetCore.Components.ComponentBase
    {
        protected internal override void CascadeParameters()
        {
            RequestCascadingParameter<Microsoft.AspNetCore.Components.Forms.EditContext>(e => CurrentEditContext = e, cascadingParameterName: null);
            base.CascadeParameters();
        }


        protected internal override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            foreach (var message in CurrentEditContext.GetValidationMessages(_fieldIdentifier))
            {
                __frame0.Element("div", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("class", "validation-message");
                    __attribute.Set("@attributes", (this.As<IReadOnlyDictionary<string, object>>()));
                }, (__frame1, __key1) =>
                {
                    __frame1.Content(message, key: __key1, sequenceNumber: -1251274529);
                }, key: message, sequenceNumber: -1251274528);
            }
        }

    }
}

