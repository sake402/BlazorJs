using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using BlazorJs.Core;

namespace BlazorJs.Sample
{
    public partial class Component2
    {
        int field1;
        int field2;
        RenderFragment view;
        public string Property1 { get; set; }
        public int Property2 { get; set; }
        public RenderFragment<string> ChildContent { get; set; }
        public RenderFragment Property3 { get; set; }
        public RenderFragment<int> Property4 { get; set; }
        [CascadingParameter("C1")] public Component1 C1 { get; set; }
    }
}
