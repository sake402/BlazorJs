//// Licensed to the .NET Foundation under one or more agreements.
//// The .NET Foundation licenses this file to you under the MIT license.

//using System.Diagnostics.CodeAnalysis;

//namespace Microsoft.AspNetCore.Components.Routing
//{
//    internal sealed partial class QueryParameterNameComparer : IComparer<ReadOnlySpan<char>>, IEqualityComparer<ReadOnlySpan<char>>
//    {
//        public static readonly QueryParameterNameComparer Instance = new QueryParameterNameComparer();

//        public int Compare(ReadOnlySpan<char> x, ReadOnlySpan<char> y)
//            => x.CompareTo(y, StringComparison.OrdinalIgnoreCase);

//        public bool Equals(ReadOnlySpan<char> x, ReadOnlySpan<char> y)
//            => x.IsEqual(y, StringComparison.OrdinalIgnoreCase);

//        public int GetHashCode(ReadOnlySpan<char> obj)
//            => string.GetHashCode(obj.AsString(), StringComparison.OrdinalIgnoreCase);
//    }
//}