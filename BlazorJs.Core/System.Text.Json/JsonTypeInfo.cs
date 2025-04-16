using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Json.Serialization.Metadata
{
    public partial class JsonTypeInfo
    {
        public JsonTypeInfo(Type type)
        {
            Type = type;
        }

        public Type Type { get; }
    }

    public partial class JsonTypeInfo<T> : JsonTypeInfo
    {
        public JsonTypeInfo() : base(typeof(T))
        {
        }
    }
}
