﻿namespace BlazorJs.Compiler.Razor
{
    public class RazorPage
    {
        public RazorPage(string route)
        {
            Route = route;
        }

        public string Route { get;set;}

        public override string ToString()
        {
            return $"@page \"{Route}\"";
        }
    }
}
