using System;

namespace Microsoft.AspNetCore.Components
{
    [Flags]
    public enum EventCallbackFlags
    {
        None,
        StopPropagation = 1 << 0,
        PreventDefault = 1 << 1
    }
}
