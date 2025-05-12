// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.JSInterop
{

    /// <summary>
    /// Provides convenience methods to produce a <see cref="DotNetObjectReference{TValue}" />.
    /// </summary>
    public static class DotNetObjectReference
    {
        /// <summary>
        /// Creates a new instance of <see cref="DotNetObjectReference{TValue}" />.
        /// </summary>
        /// <param name="value">The reference type to track.</param>
        /// <returns>An instance of <see cref="DotNetObjectReference{TValue}" />.</returns>
        public static DotNetObjectReference<TValue> Create<TValue>(TValue value) where TValue : class
        {
            ArgumentNullExceptionExtension.ThrowIfNull(value);

            return new DotNetObjectReference<TValue>(value);
        }
    }
}
