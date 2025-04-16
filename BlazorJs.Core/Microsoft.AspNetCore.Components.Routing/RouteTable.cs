// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace Microsoft.AspNetCore.Components.Routing
{
    internal sealed partial class RouteTable/*(TreeRouter treeRouter)*/
    {
        //private readonly TreeRouter _router = treeRouter;
        //private static readonly Dictionary<(Type, string), InboundRouteEntry> _routeEntryCache = new Dictionary<(Type, string), InboundRouteEntry>();

        //public TreeRouter? TreeRouter => _router;
        Dictionary<Type, string[]> _templatesByHandler;

        public RouteTable(Dictionary<Type, string[]> templatesByHandler)
        {
            _templatesByHandler = templatesByHandler;
        }

        //internal static RouteData ProcessParameters(RouteData endpointRouteData)
        //{
        //    if (endpointRouteData.Template != null)
        //    {
        //        if (!_routeEntryCache.TryGetValue((endpointRouteData.PageType, endpointRouteData.Template), out var entry))
        //        {
        //            entry = RouteTableFactory.CreateEntry(endpointRouteData.PageType, endpointRouteData.Template);
        //        }
        //        var routeValueDictionary = new RouteValueDictionary(endpointRouteData.RouteValues);
        //        foreach (var kvp in endpointRouteData.RouteValues)
        //        {
        //            if (kvp.Value is string value)
        //            {
        //                // At this point the values have already been URL decoded, but we might not have decoded '/' characters.
        //                // as that can cause issues when routing the request (You wouldn't be able to accept parameters that contained '/').
        //                // To be consistent with existing Blazor quirks that used Uri.UnescapeDataString, we'll replace %2F with /.
        //                // We don't want to call Uri.UnescapeDataString here as that would decode other characters that we don't want to decode,
        //                // for example, any value that was "double" encoded (for whatever reason) within the original URL.
        //                routeValueDictionary[kvp.Key] = value.Replace("%2F", "/").Replace("%2f", "/");
        //            }
        //        }
        //        ProcessParameters(entry, routeValueDictionary);
        //        return new RouteData(endpointRouteData.PageType, routeValueDictionary)
        //        {
        //            Template = endpointRouteData.Template
        //        };
        //    }
        //    else
        //    {
        //        return endpointRouteData;
        //    }
        //}

        public RouteData Route(string locationPath)
        {
            var registeredRoute = RouteTableFactory.Match(locationPath, out _, out var parameter);
            if (registeredRoute != null)
            {
                return new RouteData(registeredRoute.PageType, parameter != null ? object.GetOwnPropertyNames(parameter).ToDictionary(name => name, name => parameter[name]) : new Dictionary<string, object>());
            }
            var found = _templatesByHandler.SelectMany(t => t.Value.Select(pattern =>
            {
                object iparameter = new object();
                var weight = RouteTableFactory.MatchPath(pattern, locationPath, iparameter);
                return (t.Key, pattern, weight, iparameter);
            })).MaxBy(t => t.weight);
            if (found.Key != null)
            {
                return new RouteData(found.Key, found.iparameter != null ? object.GetOwnPropertyNames(found.iparameter).ToDictionary(name => name, name => found.iparameter[name]) : new Dictionary<string, object>());
            }
            return null;
            //_router.Route(routeContext);
            //if (routeContext.Entry != null)
            //{
            //    ProcessParameters(routeContext.Entry, routeContext.RouteValues);
            //}

            //if (routeContext.RouteValues != null && routeContext.RouteValues.Count == 0)
            //{
            //    routeContext.RouteValues = null;
            //}
            //return;
        }

        //private static void ProcessParameters(InboundRouteEntry entry, RouteValueDictionary routeValues)
        //{
        //    // Add null values for unused route parameters.
        //    if (entry.UnusedRouteParameterNames != null)
        //    {
        //        foreach (var parameter in entry.UnusedRouteParameterNames)
        //        {
        //            routeValues[parameter] = null;
        //        }
        //    }

        //    foreach (var kvp in routeValues)
        //    {
        //        if (kvp.Value is string value)
        //        {
        //            // At this point the values have already been URL decoded, but we might not have decoded '/' characters.
        //            // as that can cause issues when routing the request (You wouldn't be able to accept parameters that contained '/').
        //            // To be consistent with existing Blazor quirks that used Uri.UnescapeDataString, we'll replace %2F with /.
        //            // We don't want to call Uri.UnescapeDataString here as that would decode other characters that we don't want to decode,
        //            // for example, any value that was "double" encoded (for whatever reason) within the original URL.
        //            routeValues[kvp.Key] = value.Replace("%2F", "/").Replace("%2f", "/");
        //        }
        //    }

        //    foreach (var parameter in entry.RoutePattern.Parameters)
        //    {
        //        // Add null values for optional route parameters that weren't provided.
        //        if (!routeValues.TryGetValue(parameter.Name, out var parameterValue))
        //        {
        //            routeValues.Add(parameter.Name, null);
        //        }
        //        else if (parameter.ParameterPolicies.Count > 0 && !parameter.IsCatchAll)
        //        {
        //            // If the parameter has some well-known set of route constraints, then we need to convert the value
        //            // to the target type.
        //            for (var i = 0; i < parameter.ParameterPolicies.Count; i++)
        //            {
        //                var policy = parameter.ParameterPolicies[i];
        //                switch (policy.Content)
        //                {
        //                    case "bool":
        //                        routeValues[parameter.Name] = bool.Parse((string)parameterValue);
        //                        break;
        //                    case "datetime":
        //                        routeValues[parameter.Name] = DateTime.Parse((string)parameterValue, CultureInfo.InvariantCulture);
        //                        break;
        //                    case "decimal":
        //                        routeValues[parameter.Name] = decimal.Parse((string)parameterValue, CultureInfo.InvariantCulture);
        //                        break;
        //                    case "double":
        //                        routeValues[parameter.Name] = double.Parse((string)parameterValue, CultureInfo.InvariantCulture);
        //                        break;
        //                    case "float":
        //                        routeValues[parameter.Name] = float.Parse((string)parameterValue);
        //                        break;
        //                    case "guid":
        //                        routeValues[parameter.Name] = Guid.Parse((string)parameterValue);
        //                        break;
        //                    case "int":
        //                        routeValues[parameter.Name] = int.Parse((string)parameterValue);
        //                        break;
        //                    case "long":
        //                        routeValues[parameter.Name] = long.Parse((string)parameterValue);
        //                        break;
        //                    default:
        //                        continue;
        //                }
        //            }
        //        }
        //    }
        //}
    }
}