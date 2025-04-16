using System;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Components.Routing
{
    partial class RouteRegistration : RouteData
    {
        static readonly IReadOnlyDictionary<string, object> _emptyParametersDictionary
            = new Dictionary<string, object>();
        public RouteRegistration(Type pageType) : base(pageType, _emptyParametersDictionary)
        {
        }

        public Type Layout { get; set; }
        public Action<object, string, string> ParameterSetter { get; set; }
    }
}
