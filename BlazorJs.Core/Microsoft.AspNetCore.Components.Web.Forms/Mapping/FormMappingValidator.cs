// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Microsoft.AspNetCore.Components.Forms.Mapping
{
    /// <summary>
    /// Exposes validation messages for a given <see cref="FormMappingContext"/>.
    /// </summary>
    internal partial class FormMappingValidator : ComponentBase
    {
        private IDisposable _subscriptions;
        private EditContext _originalEditContext;

        [Parameter] public EditContext CurrentEditContext { get; set; }

        [CascadingParameter] internal FormMappingContext MappingContext { get; set; }

        /// <inheritdoc />
        protected internal override void OnInitialized()
        {
            if (CurrentEditContext == null)
            {
                throw new InvalidOperationException($"{nameof(FormMappingValidator)} requires a " +
                    $"parameter of type {nameof(EditContext)}.");
            }

            if (MappingContext == null)
            {
                return;
            }

            _subscriptions = CurrentEditContext.EnableFormMappingContextExtensions(MappingContext);
            _originalEditContext = CurrentEditContext;
        }

        /// <inheritdoc />
        protected internal override void OnParametersSet()
        {
            if (MappingContext == null)
            {
                return;
            }

            if (CurrentEditContext != _originalEditContext)
            {
                // While we could support this, there's no known use case presently. Since InputBase doesn't support it,
                // it's more understandable to have the same restriction.
                throw new InvalidOperationException($"{GetType()} does not support changing the " +
                    $"{nameof(EditContext)} dynamically.");
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            _subscriptions?.Dispose();
            _subscriptions = null;
        }
    }
}