using H5;

namespace System.Diagnostics.CodeAnalysis
{
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    [External]
    public sealed class DisallowNullAttribute : Attribute
    {

    }
}
