﻿namespace BlazorJs.Generator.Generator
{
    public class RazorAttribute
    {
        public RazorAttribute(string attribute)
        {
            Attribute = attribute;
        }

        public string Attribute { get;set;}

        public override string ToString()
        {
            return $"@attribute {Attribute}";
        }
    }
}
