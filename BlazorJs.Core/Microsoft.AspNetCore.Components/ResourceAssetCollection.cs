using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.AspNetCore.Components
{

    public class ResourceAssetCollection : IReadOnlyList<ResourceAsset>
    {
        public static readonly ResourceAssetCollection Empty = new ResourceAssetCollection();
        /// <summary>
        /// Gets the unique content-based URL for the specified static asset.
        /// </summary>
        /// <param name="key">The asset name.</param>
        /// <returns>The unique URL if availabe, the same <paramref name="key"/> if not available.</returns>
        public string this[string key] => null;

        /// <summary>
        /// Determines whether the specified path is a content-specific URL.
        /// </summary>
        /// <param name="path">The path to check.</param>
        /// <returns><c>true</c> if the path is a content-specific URL; otherwise, <c>false</c>.</returns>
        public bool IsContentSpecificUrl(string path) => false;

        // IReadOnlyList<ResourceAsset> implementation
        ResourceAsset IReadOnlyList<ResourceAsset>.this[int index] => null;
        int IReadOnlyCollection<ResourceAsset>.Count => 0;
        IEnumerator<ResourceAsset> IEnumerable<ResourceAsset>.GetEnumerator() => Enumerable.Empty<ResourceAsset>().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Enumerable.Empty<ResourceAsset>().GetEnumerator();
    }
}
