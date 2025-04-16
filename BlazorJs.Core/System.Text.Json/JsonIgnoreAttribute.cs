using H5;

namespace System.Text.Json.Serialization
{
    //
    // Summary:
    //     Prevents a property from being serialized or deserialized.
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    [External]
    public sealed class JsonIgnoreAttribute : JsonAttribute
    {
        //
        // Summary:
        //     Initializes a new instance of System.Text.Json.Serialization.JsonIgnoreAttribute.
        public JsonIgnoreAttribute() { }

        //
        // Summary:
        //     Gets or sets the condition that must be met before a property will be ignored.
        public JsonIgnoreCondition Condition { get; set; }
    }
}
