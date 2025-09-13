using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Microsoft.AspNetCore.Components.Web
{
    public partial class ErrorBoundary : Microsoft.AspNetCore.Components.ErrorBoundaryBase
    {
        protected internal override void InjectServices(IServiceProvider provider)
        {
            ErrorBoundaryLogger = provider.GetRequiredService<Microsoft.AspNetCore.Components.Web.IErrorBoundaryLogger>();

        }


    }
}

