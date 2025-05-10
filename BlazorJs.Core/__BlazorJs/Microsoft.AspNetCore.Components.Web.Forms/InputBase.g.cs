using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms.Mapping;


namespace Microsoft.AspNetCore.Components.Forms
{
    public partial class InputBase<TValue> : Microsoft.AspNetCore.Components.ComponentBase
    {
        protected internal override void CascadeParameters()
        {
            RequestCascadingParameter<Microsoft.AspNetCore.Components.Forms.EditContext>(e => CascadedEditContext = e, cascadingParameterName: null);
            RequestCascadingParameter<Microsoft.AspNetCore.Components.Forms.HtmlFieldPrefix>(e => FieldPrefix = e, cascadingParameterName: null);
            base.CascadeParameters();
        }


    }
}

