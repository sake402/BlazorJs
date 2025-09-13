using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Rendering;


namespace Microsoft.AspNetCore.Components.Forms
{
    public partial class InputFile : Microsoft.AspNetCore.Components.ComponentBase
    {

        protected internal override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            Element = __frame0.Element("input", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("type", "file");
                __attribute.Set("@attributes", (this.As<IReadOnlyDictionary<string, object>>()));
            }, null, sequenceNumber: 767529758);
        }

    }
}

