#if !SILVERLIGHT
namespace System.ComponentModel.DataAnnotations
{
    using System;

    /// <summary>
    /// Used for associating a metadata class with the entity class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed partial class MetadataTypeAttribute : Attribute
    {

        private Type _metadataClassType;

        public Type MetadataClassType
        {
            get
            {
                if (_metadataClassType == null)
                {
                    throw new InvalidOperationException("MetadataTypeAttribute_TypeCannotBeNull");
                }

                return _metadataClassType;
            }
        }

        public MetadataTypeAttribute(Type metadataClassType)
        {
            _metadataClassType = metadataClassType;
        }

    }
}
#endif
