using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Json
{
    public class JsonDocument
    {
        internal JsonDocument(object obj)
        {
            Object = obj;
        }
        internal object Object { get; }
        public JsonElement RootElement => new JsonElement(Object);
        public static JsonDocument Parse(string json, JsonDocumentOptions options)
        {
            var _object = JsonSerializer.Deserialize<object>(json);
            return new JsonDocument(_object);
        }
    }
}
