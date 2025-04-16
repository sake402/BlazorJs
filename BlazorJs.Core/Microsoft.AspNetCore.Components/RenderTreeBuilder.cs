using System;
using System.Collections.Generic;
using System.Text;
using BlazorJs.Core;

namespace Microsoft.AspNetCore.Components.Rendering
{
    //make razor generator happy
    public partial interface RenderTreeBuilder : IUIFrame
    {

    }

    public static partial class RenderTreeBuilderExtension
    {
        public static void AddAttribute(this IUIFrame builder, int sequenceNumber, string name, object value)
        {
        }
        public static void AddContent(this IUIFrame builder, int sequenceNumber, RenderFragment content)
        {
        }

        public static void AddContent(this IUIFrame builder, int sequenceNumber, string content)
        {
        }

        public static void AddMultipleAttributes(this IUIFrame builder, int sequenceNumber, IReadOnlyDictionary<string, object> content)
        {
        }
        public static void SetKey(this IUIFrame builder, int sequenceNumber, string key)
        {
        }
    }
}
