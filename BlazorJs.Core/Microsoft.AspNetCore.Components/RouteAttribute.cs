using System;

namespace Microsoft.AspNetCore.Components
{
    /// <summary>
    /// Indicates that the associated component should match the specified route template pattern.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public sealed partial class RouteAttribute : Attribute
    {
        /// <summary>
        /// Constructs an instance of <see cref="RouteAttribute"/>.
        /// </summary>
        /// <param name="template">The route template.</param>
        public RouteAttribute(string template)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(template);

            Template = template;
        }

        /// <summary>
        /// Gets the route template.
        /// </summary>
        public string Template { get; }
    }
}
