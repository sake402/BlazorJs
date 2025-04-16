using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Rendering;


namespace Microsoft.AspNetCore.Components.Forms
{
    public partial class ValidationSummary : Microsoft.AspNetCore.Components.ComponentBase
    {
        protected internal override void CascadeParameters()
        {
            RequestCascadingParameter<Microsoft.AspNetCore.Components.Forms.EditContext>(e => CurrentEditContext = e, cascadingParameterName: null);
            base.CascadeParameters();
        }


        protected internal override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            
            
            var validationMessages = Model is null ?
    CurrentEditContext.GetValidationMessages() :
    CurrentEditContext.GetValidationMessages(new FieldIdentifier(Model, string.Empty));
            
            if (validationMessages.Any())
            {
                __frame0.Element("ul", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("class", "validation-errors");
                    __attribute.Set("@attributes", (this.As<IReadOnlyDictionary<string, object>>()));
                }, (__frame1, __key1) =>
                {
                    foreach (var error in validationMessages)
                    {
                        __frame1.Element("li", (ref UIElementAttribute __attribute) =>
                        {
                            __attribute.Set("class", "validation-message");
                        }, (__frame2, __key2) =>
                        {
                            __frame2.Content(error, key: __key2, sequenceNumber: 619912414);
                        }, key: error, sequenceNumber: 619912415);
                    }
                }, sequenceNumber: 619912416);
            }
        }

    }
}

