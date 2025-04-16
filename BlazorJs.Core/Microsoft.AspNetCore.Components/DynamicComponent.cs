using System;
using System.Collections.Generic;
using System.Text;
using BlazorJs.Core;

namespace Microsoft.AspNetCore.Components
{
    public partial class DynamicComponent : ComponentBase
    {
        [Parameter] public Type Type { get; set; }
        [Parameter] public Dictionary<string, object> Properties { get; set; }
        [Parameter] public Action<IComponent> ParameterSetter { get; set; }

        protected internal override void BuildRenderTree(IUIFrame frame, object key = null)
        {
            if (Type != null)
            {
                frame.Component(Type, (component) =>
                {
                    if (Properties != null)
                    {
                        foreach (var kv in Properties)
                        {
                            component[kv.Key] = kv.Value;
                        }
                    }
                    ParameterSetter?.Invoke(component);
                }, sequenceNumber: Utility.DynamicComponent_SequenceNumber + Type.GetHashCode());
            }
        }
    }

    public partial class DynamicComponentT<TComponent> : ComponentBase
        where TComponent : IComponent
    {
        [Parameter] public Dictionary<string, object> Properties { get; set; }
        [Parameter] public Action<TComponent> ParameterSetter { get; set; }

        protected internal override void BuildRenderTree(IUIFrame frame, object key = null)
        {
            frame.Component<TComponent>((component) =>
            {
                if (Properties != null)
                {
                    foreach (var kv in Properties)
                    {
                        component[kv.Key] = kv.Value;
                    }
                }
                ParameterSetter?.Invoke(component);
            }, sequenceNumber: Utility.DynamicComponent_SequenceNumber + typeof(TComponent).GetHashCode());
        }
    }
}
