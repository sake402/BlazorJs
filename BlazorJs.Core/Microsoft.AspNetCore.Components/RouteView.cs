using Microsoft.AspNetCore.Components.Rendering;
using BlazorJs.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace Microsoft.AspNetCore.Components
{
    /// <summary>
    /// Displays the specified page component, rendering it inside its layout
    /// and any further nested layouts.
    /// </summary>
    public partial class RouteView : ComponentBase
    {
        private static readonly Dictionary<Type, Type> _layoutAttributeCache = new Dictionary<Type, Type>();

        //static RouteView()
        //{
        //    //if (HotReloadManager.Default.MetadataUpdateSupported)
        //    //{
        //    //    HotReloadManager.Default.OnDeltaApplied += _layoutAttributeCache.Clear;
        //    //}
        //}

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        /// <summary>
        /// Gets or sets the route data. This determines the page that will be
        /// displayed and the parameter values that will be supplied to the page.
        /// </summary>
        [Parameter]
        [EditorRequired]
        public RouteData RouteData { get; set; }

        /// <summary>
        /// Gets or sets the type of a layout to be used if the page does not
        /// declare any layout. If specified, the type must implement <see cref="IComponent"/>
        /// and accept a parameter named <see cref="LayoutComponentBase.Body"/>.
        /// </summary>
        [Parameter]
        public Type DefaultLayout { get; set; }

        protected internal override void OnParametersSet()
        {
            if (RouteData == null)
            {
                throw new InvalidOperationException($"The {nameof(RouteView)} component requires a non-null value for the parameter {nameof(RouteData)}.");
            }
            base.OnParametersSet();
        }
        /// <summary>
        /// Renders the component.
        /// </summary>
        /// <param name="builder">The <see cref="IUIFrame"/>.</param>
        /// 
        protected internal override void BuildRenderTree(IUIFrame frame, object key = null)
        {
            if (!_layoutAttributeCache.TryGetValue(RouteData.PageType, out var pageLayoutType))
            {
                pageLayoutType = RouteData.PageType.GetCustomAttributes(typeof(LayoutAttribute), true)?.FirstOrDefault().As<LayoutAttribute>()?.LayoutType;
                _layoutAttributeCache[RouteData.PageType] = pageLayoutType;
            }

            pageLayoutType = pageLayoutType ?? DefaultLayout;

            frame.Component<LayoutView>(component =>
            {
                component.Layout = pageLayoutType;
                component.ChildContent = (RenderFragment)RenderPageWithParameters;
            }, sequenceNumber: Utility.RouteView_LayoutView_SequenceNumber);
        }

        private void RenderPageWithParameters(IUIFrame frame, object key = null)
        {
            frame.Component(RouteData.PageType, component =>
            {
                foreach (var kvp in RouteData.RouteValues)
                {
                    component[kvp.Key] = kvp.Value;
                }
            }, key: key, sequenceNumber: Utility.RouteView_Page_SequenceNumber);
        }
    }
}
