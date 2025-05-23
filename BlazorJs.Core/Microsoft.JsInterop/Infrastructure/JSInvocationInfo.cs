// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;

namespace Microsoft.JSInterop.Infrastructure
{

    /// <summary>
    /// Configuration of an interop call from .NET to JavaScript.
    /// </summary>
    public /*readonly*/ struct JSInvocationInfo
    {
        private /*readonly*/ string _argsJson;

        /// <summary>
        /// The identifier for the interop call, or zero if no async callback is required.
        /// </summary>
        public /*required*/ long AsyncHandle { get; set; }

        /// <summary>
        /// The instance ID of the target JS object.
        /// </summary>
        public /*required*/ long TargetInstanceId { get; set; }

        /// <summary>
        /// The identifier of the function to invoke or property to access.
        /// </summary>
        public /*required*/ string Identifier { get; set; }

        /// <summary>
        /// The type of operation that should be performed in JS.
        /// </summary>
        public /*required*/ JSCallType CallType { get; set; }

        /// <summary>
        /// The type of result expected from the invocation.
        /// </summary>
        public /*required*/ JSCallResultType ResultType { get; set; }

        /// <summary>
        /// A JSON representation of the arguments.
        /// </summary>
        public /*required*/ string ArgsJson
        {
            get => _argsJson ?? "[]";
            set => _argsJson = value;
        }
    }
}