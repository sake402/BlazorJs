using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorJs.Compiler.RazorToCSharp
{
    public class RazorUsing
    {
        public RazorUsing(string @namespace)
        {
            Namespace = @namespace;
        }

        public string Namespace { get; }

        public override string ToString()
        {
            return $"@using {Namespace}";
        }
    }
}
