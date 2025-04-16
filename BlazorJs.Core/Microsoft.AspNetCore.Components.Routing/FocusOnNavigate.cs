using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlazorJs.Core;
using static H5.Core.dom;

namespace Microsoft.AspNetCore.Components.Routing
{
    /// <summary>
    /// After navigating from one page to another, sets focus to an element
    /// matching a CSS selector. This can be used to build an accessible
    /// navigation system compatible with screen readers.
    /// </summary>
    public partial class FocusOnNavigate : ComponentBase
    {
        private const string CustomElementName = "blazor-focus-on-navigate";

        private Type _lastNavigatedPageType = typeof(NonMatchingType);
        private bool _focusAfterRender;

        /// <summary>
        /// Gets or sets the route data. This can be obtained from an enclosing
        /// <see cref="Router"/> component.
        /// </summary>
        [Parameter] public RouteData RouteData { get; set; } // TODO: [EditorRequired]

        /// <summary>
        /// Gets or sets a CSS selector describing the element to be focused after
        /// navigation between pages.
        /// </summary>
        [Parameter] public string Selector { get; set; } // TODO: [EditorRequired]

        /// <inheritdoc />
        protected internal override void OnParametersSet()
        {
            if (RouteData is null)
            {
                throw new InvalidOperationException($"{nameof(FocusOnNavigate)} requires a non-null value for the parameter '{nameof(RouteData)}'.");
            }

            if (string.IsNullOrWhiteSpace(Selector))
            {
                throw new InvalidOperationException($"{nameof(FocusOnNavigate)} requires a nonempty value for the parameter '{nameof(Selector)}'.");
            }

            // We focus whenever the page type changes, including to or from 'null'
            if (RouteData.PageType != _lastNavigatedPageType)
            {
                _lastNavigatedPageType = RouteData.PageType;
                _focusAfterRender = true;
            }
        }

        protected internal override void BuildRenderTree(IUIFrame frame, object key = null)
        {
            //if (AssignedRenderMode != null)
            //{
            //    // When interactivity is enabled, functionality is handled via JS interop.
            //    // We don't need to render anything to the page in that case.
            //    // In non-interactive scenarios, a custom element is rendered so that
            //    // JS logic can find it and focus the element matching the specified
            //    // selector.
            //    return;
            //}

            //frame.Element(CustomElementName, (ref UIElementAttribute attribute) =>
            //{
            //    attribute.Set("selector", Selector);
            //});
        }

        /// <inheritdoc />
        protected internal override void OnAfterRender(bool firstRender)
        {
            if (_focusAfterRender)
            {
                _focusAfterRender = false;
                var element = document.querySelector<HTMLElement>(Selector).As<HTMLElement>();
                if (element != null)
                    element.scrollIntoView();
            }
            base.OnAfterRender(firstRender);
        }

        // On the first render, we always want to consider the page type changed, even if it's null.
        // So we need some other non-null type to compare with it.
        private sealed partial class NonMatchingType { }
    }
}
