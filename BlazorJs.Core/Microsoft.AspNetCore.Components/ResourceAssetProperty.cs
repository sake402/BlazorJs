using H5;

namespace Microsoft.AspNetCore.Components
{
    /// <summary>
    /// A resource property.
    /// </summary>
    /// <param name="name">The name of the property.</param>
    /// <param name="value">The value of the property.</param>
    public sealed class ResourceAssetProperty//(string name, string value)
    {
        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        public string Name { get; }// = name;

        /// <summary>
        /// Gets the value of the property.
        /// </summary>
        public string Value { get; }// = value;
    }
}
