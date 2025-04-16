using H5;

namespace System.Text.Json.Serialization
{
    //
    // Summary:
    //     Specifies the property name that is present in the JSON when serializing and
    //     deserializing. This overrides any naming policy specified by System.Text.Json.JsonNamingPolicy.
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    [External]
    public sealed class JsonPropertyNameAttribute : JsonAttribute
    {
        //
        // Summary:
        //     Initializes a new instance of System.Text.Json.Serialization.JsonPropertyNameAttribute
        //     with the specified property name.
        //
        // Parameters:
        //   name:
        //     The name of the property.
        public JsonPropertyNameAttribute(string name) { Name = name; }

        //
        // Summary:
        //     Gets the name of the property.
        //
        // Returns:
        //     The name of the property.
        public string Name { get; }
    }
}
