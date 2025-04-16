// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace System.Net.Http.Json
{
    internal static partial class JsonHelpers
    {
        internal static JsonTypeInfo GetJsonTypeInfo(Type type, JsonSerializerOptions options)
        {
            Debug.Assert(!(type is null));
            return new JsonTypeInfo(type);

            // Resolves JsonTypeInfo metadata using the appropriate JsonSerializerOptions configuration,
            // following the semantics of the JsonSerializer reflection methods.
            //options = options ?? JsonSerializerOptions.Web;
            //options.MakeReadOnly(populateMissingResolver: true);
            //return options.GetTypeInfo(type);
        }

        internal const string DefaultMediaType = "application/json; charset=utf-8";

        internal static Encoding GetEncoding(HttpContent content)
        {
            Encoding encoding = null;

            if (content.Headers.ContentType?.CharSet is string charset)
            {
                try
                {
                    // Remove at most a single set of quotes.
                    if (charset.Length > 2 && charset[0] == '\"' && charset[charset.Length - 1] == '\"')
                    {
                        encoding = Encoding.GetEncoding(charset.Substring(1, charset.Length - 2));
                    }
                    else
                    {
                        encoding = Encoding.GetEncoding(charset);
                    }
                }
                catch (ArgumentException e)
                {
                    throw new InvalidOperationException("CharSetInvalid", e);
                }

                Debug.Assert(encoding != null);
            }

            return encoding;
        }
    }
}
