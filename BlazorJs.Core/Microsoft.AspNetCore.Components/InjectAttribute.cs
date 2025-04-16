using System;

namespace Microsoft.AspNetCore.Components
{
    public partial class InjectAttribute : Attribute
    {
        public InjectAttribute(bool required = true)
        {
        }
    }
}
