// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Rendering;
using static H5.Core.dom;

namespace Microsoft.AspNetCore.Components.Forms
{
    /// <summary>
    /// A component that wraps the HTML file input element and supplies a <see cref="Stream"/> for each file's contents.
    /// </summary>
    public partial class InputFile : ComponentBase, IInputFileJsCallbacks
    {
        private HTMLElement _inputFileElement;

        //private InputFileJsCallbacksRelay _jsCallbacksRelay;

        /// <summary>
        /// Gets or sets the event callback that will be invoked when the collection of selected files changes.
        /// </summary>
        [Parameter]
        public EventCallback<InputFileChangeEventArgs> OnChange { get; set; }

        ///// <summary>
        ///// Gets or sets a collection of additional attributes that will be applied to the input element.
        ///// </summary>
        //[Parameter(CaptureUnmatchedValues = true)]
        //public IDictionary<string, object>? AdditionalAttributes { get; set; }

        /// <summary>
        /// Gets or sets the associated <see cref="ElementReference"/>.
        /// <para>
        /// May be <see langword="null"/> if accessed before the component is rendered.
        /// </para>
        /// </summary>
        public HTMLElement Element
        {
            get => _inputFileElement;
            protected set => _inputFileElement = value;
        }

        protected internal override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                //_jsCallbacksRelay = new InputFileJsCallbacksRelay(this);
                InputFileInterop.Init(this, _inputFileElement.As<HTMLInputElement>());
            }
            base.OnAfterRender(firstRender);
        }

        ///// <inheritdoc/>
        //protected override void BuildRenderTree(RenderTreeBuilder builder)
        //{
        //    builder.OpenElement(0, "input");
        //    builder.AddMultipleAttributes(1, AdditionalAttributes);
        //    builder.AddAttribute(2, "type", "file");
        //    builder.AddElementReferenceCapture(3, elementReference => _inputFileElement = elementReference);
        //    builder.CloseElement();
        //}

        internal Stream OpenReadStream(BrowserFile file, long maxAllowedSize, CancellationToken cancellationToken)
            => new BrowserFileStream(
                _inputFileElement.As<HTMLInputElement>(),
                file,
                maxAllowedSize,
                cancellationToken);

        internal async Task<IBrowserFile> ConvertToImageFileAsync(BrowserFile file, string format, int maxWidth, int maxHeight)
        {
            var imageFile = await InputFileInterop.ToImageFile(_inputFileElement.As<HTMLInputElement>(), file.Id, format, maxWidth, maxHeight);

            if (imageFile is null)
            {
                throw new InvalidOperationException("ToImageFile returned an unexpected null result.");
            }

            imageFile.Owner = this;

            return imageFile;
        }

        Task IInputFileJsCallbacks.NotifyChange(BrowserFile[] files)
        {
            foreach (var file in files)
            {
                file.Owner = this;
            }

            return OnChange.InvokeAsync(new InputFileChangeEventArgs(files));
        }

        //public override void Dispose()
        //{
        //    //_jsCallbacksRelay?.Dispose();
        //    base.Dispose();
        //}
    }
}
