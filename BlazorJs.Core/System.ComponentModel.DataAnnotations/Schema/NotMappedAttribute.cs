using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel.DataAnnotations.Schema
{
    /// <summary>
    /// Denotes that a property or class should be excluded from database mapping.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Class, AllowMultiple = false)]
    public partial class NotMappedAttribute : Attribute
    {
    }
}