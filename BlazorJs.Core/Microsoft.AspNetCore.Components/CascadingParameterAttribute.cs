using System;

namespace Microsoft.AspNetCore.Components
{
    public partial class CascadingParameterAttribute : Attribute
    {
        public CascadingParameterAttribute()
        {
        }

        public CascadingParameterAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
