using System;
using static H5.Core.dom;

namespace Microsoft.AspNetCore.Components
{
    /// <summary>
    /// Represents a reference to a rendered element.
    /// </summary>
    public struct ElementReference
    {
        public HTMLElement Element { get; set; }

        public static implicit operator ElementReference(HTMLElement element) => new ElementReference() { Element = element };
    }
}
