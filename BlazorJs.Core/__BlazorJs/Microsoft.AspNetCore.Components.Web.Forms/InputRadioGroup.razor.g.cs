using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components.Rendering;


namespace Microsoft.AspNetCore.Components.Forms
{
    public partial class InputRadioGroup<TValue> : InputBase<TValue>
    {
        protected internal override void CascadeParameters()
        {
            RequestCascadingParameter<Microsoft.AspNetCore.Components.Forms.InputRadioContext>(e => CascadedContext = e, cascadingParameterName: null);
            base.CascadeParameters();
        }


        protected internal override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            
            
            Debug.Assert(_context != null);
            
            __frame0.Component<CascadingValue<InputRadioContext>>((__component0) =>
            {
                __component0.Value = _context;
                __component0.ChildContent = (__frame1, __key1) =>
                {
                    __frame1.Content(ChildContent, key: __key1, sequenceNumber: -1219518615);
                };
            }, sequenceNumber: -1219518614);
        }

    }
}

