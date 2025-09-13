using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorJs.Sample
{
    public partial class GenericComponent1<T1, T2> : ComponentBase
    {
    }

    public partial class GenericComponent1Up<T1, T2> : GenericComponent1<T1, T2>
    {
    }
}
