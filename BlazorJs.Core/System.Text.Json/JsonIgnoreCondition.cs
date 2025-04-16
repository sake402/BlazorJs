using H5;

namespace System.Text.Json.Serialization
{
    //
    // Summary:
    //     Controls how the System.Text.Json.Serialization.JsonIgnoreAttribute ignores properties
    //     on serialization and deserialization.
    [External]
    public enum JsonIgnoreCondition
    {
        //
        // Summary:
        //     Property is always serialized and deserialized, regardless of System.Text.Json.JsonSerializerOptions.IgnoreNullValues
        //     configuration.
        Never = 0,
        //
        // Summary:
        //     Property is always ignored.
        Always = 1,
        //
        // Summary:
        //     Property is ignored only if it equals the default value for its type.
        WhenWritingDefault = 2,
        //
        // Summary:
        //     Property is ignored if its value is null. This is applied only to reference-type
        //     properties and fields.
        WhenWritingNull = 3
    }
}
