using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;


namespace Microsoft.AspNetCore.Components.Forms.Mapping
{
    internal partial class FormMappingValidator : Microsoft.AspNetCore.Components.ComponentBase
    {
        protected internal override void CascadeParameters()
        {
            RequestCascadingParameter<Microsoft.AspNetCore.Components.Forms.FormMappingContext>(e => MappingContext = e, cascadingParameterName: null);
            base.CascadeParameters();
        }


    }
}

