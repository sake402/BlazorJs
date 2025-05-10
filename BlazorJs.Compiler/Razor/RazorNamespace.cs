﻿namespace BlazorJs.Compiler.Razor
{
    public class RazorNamespace
    {
        public RazorNamespace(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override string ToString()
        {
            return $"@namespace {Name}";
        }
    }
}
