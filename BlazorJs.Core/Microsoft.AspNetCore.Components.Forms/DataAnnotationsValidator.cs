// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Microsoft.AspNetCore.Components.Forms
{
    /// <summary>
    /// Adds Data Annotations validation support to an <see cref="EditContext"/>.
    /// </summary>
    public partial class DataAnnotationsValidator : ComponentBase, IDisposable
    {
        private IDisposable _subscriptions;
        private EditContext _originalEditContext;

        [CascadingParameter] EditContext CurrentEditContext { get; set; }

        [Inject] private IServiceProvider ServiceProvider { get; set; }

        /// <inheritdoc />
        protected internal override void OnInitialized()
        {
            if (CurrentEditContext == null)
            {
                throw new InvalidOperationException($"{nameof(DataAnnotationsValidator)} requires a cascading " +
                    $"parameter of type {nameof(EditContext)}. For example, you can use {nameof(DataAnnotationsValidator)} " +
                    $"inside an EditForm.");
            }

            _subscriptions = CurrentEditContext.EnableDataAnnotationsValidation(ServiceProvider);
            _originalEditContext = CurrentEditContext;
        }

        /// <inheritdoc />
        protected internal override void OnParametersSet()
        {
            if (CurrentEditContext != _originalEditContext)
            {
                // While we could support this, there's no known use case presently. Since InputBase doesn't support it,
                // it's more understandable to have the same restriction.
                throw new InvalidOperationException($"{GetType()} does not support changing the " +
                    $"{nameof(EditContext)} dynamically.");
            }
        }

        /// <inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
        }

        public override void Dispose()
        {
            base.Dispose();
            _subscriptions?.Dispose();
            _subscriptions = null;

            Dispose(disposing: true);
        }
    }
}