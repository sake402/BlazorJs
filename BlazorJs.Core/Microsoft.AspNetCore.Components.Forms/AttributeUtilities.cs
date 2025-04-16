using System;
using System.Collections.Generic;
using System.Text;
using BlazorJs.Core;

namespace Microsoft.AspNetCore.Components.Forms
{
    internal static partial class AttributeUtilities
    {
        public static string CombineClassNames(object additionalAttributes, string classNames)
        {
            if (additionalAttributes is null || !additionalAttributes.TryGetValue("class", out var mclass))
            {
                return classNames;
            }

            var classAttributeValue = Convert.ToString(mclass);

            if (string.IsNullOrEmpty(classAttributeValue))
            {
                return classNames;
            }

            if (string.IsNullOrEmpty(classNames))
            {
                return classAttributeValue;
            }

            return $"{classAttributeValue} {classNames}";
        }
    }
}
