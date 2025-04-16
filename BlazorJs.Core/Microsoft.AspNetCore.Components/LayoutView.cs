using Microsoft.AspNetCore.Components.Rendering;
using BlazorJs.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Microsoft.AspNetCore.Components
{
    /// <summary>
    /// Displays the specified content inside the specified layout and any further
    /// nested layouts.
    /// </summary>
    public partial class LayoutView : ComponentBase
    {
        private static readonly RenderFragment EmptyRenderFragment = (builder, key) => { };

        /// <summary>
        /// Gets or sets the content to display.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Gets or sets the type of the layout in which to display the content.
        /// The type must implement <see cref="IComponent"/> and accept a parameter named <see cref="LayoutComponentBase.Body"/>.
        /// </summary>
        [Parameter]
        public Type Layout { get; set; }

        protected internal override void BuildRenderTree(IUIFrame frame, object key = null)
        {
            // In the middle goes the supplied content
            var fragment = ChildContent ?? EmptyRenderFragment;

            // Then repeatedly wrap that in each layer of nested layout until we get
            // to a layout that has no parent
            var layoutType = Layout;
            while (layoutType != null)
            {
                fragment = WrapInLayout(layoutType, fragment);
                layoutType = GetParentLayoutType(layoutType);
            }
            frame.Content(fragment, sequenceNumber: Utility.LayoutView_Fragment_SequenceNumber);
        }

        private static RenderFragment WrapInLayout(Type layoutType, RenderFragment bodyParam)
        {
            void Render(IUIFrame builder, object key = null)
            {
                builder.Component(layoutType, component =>
                {
                    ((LayoutComponentBase)component).Body = bodyParam;
                }, key: key, sequenceNumber: Utility.LayoutView_Layout_SequenceNumber);
            };

            return Render;
        }

        private static Type GetParentLayoutType(Type type)
            => type.GetCustomAttributes(typeof(LayoutAttribute), true).FirstOrDefault().As<LayoutAttribute>()?.LayoutType;
    }
}
