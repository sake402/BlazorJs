using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using BlazorJs.Core;

namespace Microsoft.AspNetCore.Components
{
    public partial class CascadingValue<TValue> : ComponentBase
    {
        [Parameter] public string Name { get; set; }
        [Parameter] public TValue Value { get; set; }
        [Parameter] public bool IsFixed { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        protected internal override void BuildRenderTree(IUIFrame frame, object key = null)
        {
            frame.State.SetCascadingValue(Value, IsFixed, Name);
            frame.Content(ChildContent, sequenceNumber: Utility.CascadingValue_SequenceNumber);
        }
    }
}
