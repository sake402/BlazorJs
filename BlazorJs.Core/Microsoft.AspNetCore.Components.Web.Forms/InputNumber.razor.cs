// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Microsoft.AspNetCore.Components.Rendering;

namespace Microsoft.AspNetCore.Components.Forms
{
    /// <summary>
    /// An input component for editing numeric values.
    /// Supported numeric types are <see cref="int"/>, <see cref="long"/>, <see cref="short"/>, <see cref="float"/>, <see cref="double"/>, <see cref="decimal"/>.
    /// </summary>
    public partial class InputNumber<TValue> : InputBase<TValue>
    {
        private static readonly string _stepAttributeValue = GetStepAttributeValue();

        private static string GetStepAttributeValue()
        {
            // Unwrap Nullable<T>, because InputBase already deals with the Nullable aspect
            // of it for us. We will only get asked to parse the T for nonempty inputs.
            var targetType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);
            if (targetType == typeof(int) ||
                targetType == typeof(long) ||
                targetType == typeof(short) ||
                targetType == typeof(float) ||
                targetType == typeof(double) ||
                targetType == typeof(decimal))
            {
                return "any";
            }
            else
            {
                throw new InvalidOperationException($"The type '{targetType}' is not a supported numeric type.");
            }
        }

        /// <summary>
        /// Gets or sets the error message used when displaying an a parsing error.
        /// </summary>
        [Parameter] public string ParsingErrorMessage { get; set; } = "The {0} field must be a number.";

        /// <summary>
        /// Gets or sets the associated <see cref="ElementReference"/>.
        /// <para>
        /// May be <see langword="null"/> if accessed before the component is rendered.
        /// </para>
        /// </summary>
        public ElementReference Element { get; protected set; }

        ///// <inheritdoc />
        //protected override void BuildRenderTree(RenderTreeBuilder builder)
        //{
        //    builder.OpenElement(0, "input");
        //    builder.AddAttribute(1, "step", _stepAttributeValue);
        //    builder.AddAttribute(2, "type", "number");
        //    builder.AddMultipleAttributes(3, AdditionalAttributes);
        //    builder.AddAttributeIfNotNullOrEmpty(4, "name", NameAttributeValue);
        //    builder.AddAttributeIfNotNullOrEmpty(5, "class", CssClass);
        //    builder.AddAttribute(6, "value", CurrentValueAsString);
        //    builder.AddAttribute(7, "onchange", EventCallback.Factory.CreateBinder<string?>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
        //    builder.SetUpdatesAttributeName("value");
        //    builder.AddElementReferenceCapture(8, __inputReference => Element = __inputReference);
        //    builder.CloseElement();
        //}

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage)
        {
            if (BindConverter.TryConvertTo<TValue>(value, CultureInfo.InvariantCulture, out result))
            {
                validationErrorMessage = null;
                return true;
            }
            else
            {
                validationErrorMessage = string.Format(CultureInfo.InvariantCulture, ParsingErrorMessage, DisplayName ?? FieldIdentifier.FieldName);
                return false;
            }
        }

        /// <summary>
        /// Formats the value as a string. Derived classes can override this to determine the formatting used for <c>CurrentValueAsString</c>.
        /// </summary>
        /// <param name="value">The value to format.</param>
        /// <returns>A string representation of the value.</returns>
        protected override string FormatValueAsString(TValue value)
        {
            // Avoiding a cast to IFormattable to avoid boxing.
            switch (value)
            {
                case int mint:
                    return BindConverter.FormatValue(mint, CultureInfo.InvariantCulture);

                case long mlong:
                    return BindConverter.FormatValue(mlong, CultureInfo.InvariantCulture);

                case short mshort:
                    return BindConverter.FormatValue(mshort, CultureInfo.InvariantCulture);

                case float mfloat:
                    return BindConverter.FormatValue(mfloat, CultureInfo.InvariantCulture);

                case double mdouble:
                    return BindConverter.FormatValue(mdouble, CultureInfo.InvariantCulture);

                case decimal mdecimal:
                    return BindConverter.FormatValue(mdecimal, CultureInfo.InvariantCulture);

                default:
                    if (value == null)
                        return null;
                    throw new InvalidOperationException($"Unsupported type {value.GetType()}");
            }
        }
    }
}