//// Licensed to the .NET Foundation under one or more agreements.
//// The .NET Foundation licenses this file to you under the MIT license.

//using Microsoft.AspNetCore.Routing;
//using Microsoft.AspNetCore.Routing.Patterns;

//namespace Microsoft.AspNetCore.Components.Routing
//{
//    internal partial class InboundRouteEntry
//    {
//        /// <summary>
//        /// Gets or sets the route constraints.
//        /// </summary>
//        public IDictionary<string, IRouteConstraint> Constraints { get; set; }

//        /// <summary>
//        /// Gets or sets the route defaults.
//        /// </summary>
//        public RouteValueDictionary Defaults { get; set; }

//        public Type Handler { get; set; }

//        /// <summary>
//        /// Gets or sets the order of the entry.
//        /// </summary>
//        /// <remarks>
//        /// Entries are ordered first by <see cref="Order"/> (ascending) then by <see cref="Precedence"/> (descending).
//        /// </remarks>
//        public int Order { get; set; }

//        /// <summary>
//        /// Gets or sets the precedence of the entry.
//        /// </summary>
//        /// <remarks>
//        /// Entries are ordered first by <see cref="Order"/> (ascending) then by <see cref="Precedence"/> (descending).
//        /// </remarks>
//        public decimal Precedence { get; set; }

//        /// <summary>
//        /// Gets or sets the name of the route.
//        /// </summary>
//        public string RouteName { get; set; }
//        public RoutePattern RoutePattern { get; set; }

//        public List<string> UnusedRouteParameterNames { get; set; }
//    }
//}