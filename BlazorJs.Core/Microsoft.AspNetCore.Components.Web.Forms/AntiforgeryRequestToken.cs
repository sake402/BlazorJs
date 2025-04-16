// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Microsoft.AspNetCore.Components.Forms
{
    /// <summary>
    /// The antiforgery token included in the request form data.
    /// </summary>
    public partial class AntiforgeryRequestToken
    {
        /// <summary>
        /// Initializes a new instance of <see cref="AntiforgeryRequestToken"/>.
        /// </summary>
        /// <param name="value">The antiforgery token value.</param>
        /// <param name="formFieldName">The form field name for the antiforgery token.</param>
        public AntiforgeryRequestToken(string value, string formFieldName)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(value);
            ArgumentNullExceptionExtension.ThrowIfNull(formFieldName);

            Value = value;
            FormFieldName = formFieldName;
        }

        /// <summary>
        /// Gets the antiforgery token value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Gets the form field name for the antiforgery token.
        /// </summary>
        public string FormFieldName { get; }
    }
}