﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorJs.Compiler.Razor
{
    public class RazorInherit
    {
        public RazorInherit(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override string ToString()
        {
            return $"@inherits {Name}";
        }
    }
}
