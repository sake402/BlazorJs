﻿
namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Used to mark one or more entity properties that provide the entity's unique identity
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed partial class KeyAttribute : Attribute
    {
    }
}
