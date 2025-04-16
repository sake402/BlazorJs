using System;
using System.Collections.Generic;
using System.Text;
using BlazorJs.Core;

namespace Microsoft.AspNetCore.Components
{
    public delegate void RenderFragment(IUIFrame context, object key = null);
    public delegate RenderFragment RenderFragment<T>(T data);
}
