using System;

namespace Microsoft.AspNetCore.Components
{
    public sealed partial class LocationChangeException : Exception
    {
        /// <summary>
        /// Creates a new instance of <see cref="LocationChangeException"/>.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public LocationChangeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
