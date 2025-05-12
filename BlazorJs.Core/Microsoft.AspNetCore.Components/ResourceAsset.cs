using H5;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Components
{
    public sealed class ResourceAsset//(string url, IReadOnlyList<ResourceAssetProperty> properties)
    {
        /// <summary>
        /// Gets the URL that identifies this resource.
        /// </summary>
        public string Url { get; }// = url;

        /// <summary>
        /// Gets a list of properties associated to this resource.
        /// </summary>
        public IReadOnlyList<ResourceAssetProperty> Properties { get; } //= properties;
    }
}
