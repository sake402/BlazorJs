using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;


namespace Microsoft.AspNetCore.Components.Forms
{
    public partial class DataAnnotationsValidator : Microsoft.AspNetCore.Components.ComponentBase
    {
        protected internal override void InjectServices(IServiceProvider provider)
        {
            ServiceProvider = provider.GetRequiredService<System.IServiceProvider>();

        }

        protected internal override void CascadeParameters()
        {
            RequestCascadingParameter<Microsoft.AspNetCore.Components.Forms.EditContext>(e => CurrentEditContext = e, cascadingParameterName: null);
            base.CascadeParameters();
        }


    }
}

