using BlazorJs.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Components.Web
{
    /// <summary>
    /// Captures errors thrown from its child content.
    /// </summary>
    public partial class ErrorBoundary : ErrorBoundaryBase
    {
        [Inject] private IErrorBoundaryLogger ErrorBoundaryLogger { get; set; }

        /// <summary>
        /// Invoked by the base class when an error is being handled. The default implementation
        /// logs the error.
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> being handled.</param>
        protected override async Task OnErrorAsync(Exception exception)
        {
            await ErrorBoundaryLogger.LogErrorAsync(exception);
        }

        /// <inheritdoc />
        protected internal override void BuildRenderTree(IUIFrame frame, object key = null)
        {
            if (CurrentException == null)
            {
                frame.Content(ChildContent, sequenceNumber: Utility.ErrorBoundary_ChildContent_SequenceNumber);
            }
            else if (ErrorContent != null)
            {
                frame.Content(ErrorContent(CurrentException), sequenceNumber: Utility.ErrorBoundary_ErrorContent_SequenceNumber);
            }
            else
            {
                // The default error UI doesn't include any content, because:
                // [1] We don't know whether or not you'd be happy to show the stack trace. It depends both on
                //     whether DetailedErrors is enabled and whether you're in production, because even on WebAssembly
                //     you likely don't want to put technical data like that in the UI for end users. A reasonable way
                //     to toggle this is via something like "#if DEBUG" but that can only be done in user code.
                // [2] We can't have any other human-readable content by default, because it would need to be valid
                //     for all languages.
                // Instead, the default project template provides locale-specific default content via CSS. This provides
                // a quick form of customization even without having to subclass this component.
                frame.Element("div", attributeBuilder: (ref UIElementAttribute attribute) =>
                {
                    attribute.Set("class", "blazor-error-boundary");
                }, sequenceNumber: Utility.ErrorBoundary_DefaultContent_SequenceNumber);
            }
        }
    }
}
