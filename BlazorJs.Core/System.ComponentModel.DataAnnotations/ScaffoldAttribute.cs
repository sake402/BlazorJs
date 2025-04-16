#if !SILVERLIGHT
using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public partial class ScaffoldColumnAttribute : Attribute
    {
        public bool Scaffold { get; private set; }

        public ScaffoldColumnAttribute(bool scaffold)
        {
            Scaffold = scaffold;
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public partial class ScaffoldTableAttribute : Attribute
    {
        public bool Scaffold { get; private set; }

        public ScaffoldTableAttribute(bool scaffold)
        {
            Scaffold = scaffold;
        }
    }
}
#endif
