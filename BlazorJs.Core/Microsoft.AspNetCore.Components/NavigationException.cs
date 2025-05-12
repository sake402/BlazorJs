using System;

namespace Microsoft.AspNetCore.Components
{
    /// <summary>
    /// Exception thrown when an <see cref="NavigationManager"/> is not able to navigate to a different url.
    /// </summary>
    public class NavigationException : Exception
    {
        /// <summary>
        /// Initializes a new <see cref="NavigationException"/> instance.
        /// </summary>
        public NavigationException(string uri)
        {
            Location = uri;
        }

        /// <summary>
        /// Gets the uri to which navigation was attempted.
        /// </summary>
        public string Location { get; }
    }
}
