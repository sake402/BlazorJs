using H5;
using System;

namespace Microsoft.AspNetCore.Components
{
    [ObjectLiteral]
    public class EventTarget
    {
        [Name("value")]
        public object Value { get; set; }
    }
    /// <summary>
    /// Supplies information about an change event that is being raised.
    /// </summary>
    [ObjectLiteral]
    public partial class ChangeEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the new value.
        /// </summary>
        /// 
        [Name("target")]
        public EventTarget Target { get; set; }
    }
}
