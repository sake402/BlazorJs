using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static H5.Core.dom;
using Microsoft.AspNetCore.Components;

namespace Microsoft.AspNetCore.Components
{
    public partial class PageTitle : ComponentBase
    {
        HTMLElement titleWrapper;
        [Parameter] public RenderFragment ChildContent { get; set; }
        protected internal override void OnAfterRender(bool firstRender)
        {
            document.title = titleWrapper.innerText;
            base.OnAfterRender(firstRender);
        }
    }
}
