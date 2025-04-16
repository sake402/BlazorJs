using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Components
{
    /// <summary>
    /// Describes information determined during routing that specifies
    /// the page to be displayed.
    /// </summary>
    public partial class RouteData
    {
        /// <summary>
        /// Constructs an instance of <see cref="RouteData"/>.
        /// </summary>
        /// <param name="pageType">The type of the page matching the route, which must implement <see cref="IComponent"/>.</param>
        /// <param name="routeValues">The route parameter values extracted from the matched route.</param>
        public RouteData(Type pageType, IReadOnlyDictionary<string, object> routeValues)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(pageType);

            if (!typeof(IComponent).IsAssignableFrom(pageType))
            {
                throw new ArgumentException($"The value must implement {nameof(IComponent)}.", nameof(pageType));
            }

            PageType = pageType;
            RouteValues = routeValues ?? throw new ArgumentNullException(nameof(routeValues));
        }

        /// <summary>
        /// Gets the type of the page matching the route.
        /// </summary>
        public Type PageType { get; }

        /// <summary>
        /// Gets route parameter values extracted from the matched route.
        /// </summary>
        public IReadOnlyDictionary<string, object> RouteValues { get; }

        /// <summary>
        /// Gets the route template that was used to match the route if any.
        /// </summary>
        public string Template { get; set; }
    }
}
