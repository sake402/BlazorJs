//// Licensed to the .NET Foundation under one or more agreements.
//// The .NET Foundation licenses this file to you under the MIT license.

//using System.Runtime.InteropServices;
//using Microsoft.AspNetCore.Internal;

//namespace Microsoft.AspNetCore.Components.Routing
//{
//    internal sealed partial class QueryParameterValueSupplier
//    {
//        private readonly Dictionary<ReadOnlySpan<char>, StringSegmentAccumulator> _queryParameterValuesByName = new Dictionary<ReadOnlySpan<char>, StringSegmentAccumulator>(QueryParameterNameComparer.Instance);

//        public void ReadParametersFromQuery(ReadOnlySpan<char> query)
//        {
//            _queryParameterValuesByName.Clear();

//            var queryStringEnumerable = new QueryStringEnumerable(query);

//            foreach (var suppliedPair in queryStringEnumerable)
//            {
//                var decodedName = suppliedPair.DecodeName();
//                var decodedValue = suppliedPair.DecodeValue();
//                _queryParameterValuesByName[decodedName].Add(decodedValue);
//                //// This is safe because we don't mutate the dictionary while the ref local is in scope.
//                //ref var values = ref CollectionsMarshal.GetValueRefOrAddDefault(_queryParameterValuesByName, decodedName, out _);
//                //values.Add(decodedValue);
//            }
//        }

//        public object GetQueryParameterValue(Type targetType, string queryParameterName)
//        {
//            var isArray = targetType.IsArray;
//            var elementType = isArray ? targetType.GetElementType() : targetType;

//            if (!UrlValueConstraint.TryGetByTargetType(elementType, out var parser))
//            {
//                throw new InvalidOperationException($"Querystring values cannot be parsed as type '{elementType}'.");
//            }

//            var values = _queryParameterValuesByName.GetValueOrDefault(queryParameterName.AsSpan());

//            if (isArray)
//            {
//                return parser.ParseMultiple(values, queryParameterName);
//            }

//            if (values.Count > 0)
//            {
//                return parser.Parse(values[0], queryParameterName);
//            }

//            return default;
//        }
//    }
//}