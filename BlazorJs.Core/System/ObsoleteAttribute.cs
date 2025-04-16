//using H5;

//namespace System
//{
//    //
//    // Summary:
//    //     Marks the program elements that are no longer in use. This class cannot be inherited.
//    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false)]
//    [External]
//    public sealed class ObsoleteAttribute : Attribute
//    {
//        //
//        // Summary:
//        //     Initializes a new instance of the System.ObsoleteAttribute class with default
//        //     properties.
//        public ObsoleteAttribute() { }
//        //
//        // Summary:
//        //     Initializes a new instance of the System.ObsoleteAttribute class with a specified
//        //     workaround message.
//        //
//        // Parameters:
//        //   message:
//        //     The text string that describes alternative workarounds.
//        public ObsoleteAttribute(string? message) { }
//        //
//        // Summary:
//        //     Initializes a new instance of the System.ObsoleteAttribute class with a workaround
//        //     message and a Boolean value indicating whether the obsolete element usage is
//        //     considered an error.
//        //
//        // Parameters:
//        //   message:
//        //     The text string that describes alternative workarounds.
//        //
//        //   error:
//        //     true if the obsolete element usage generates a compiler error; false if it generates
//        //     a compiler warning.
//        public ObsoleteAttribute(string? message, bool error) { }

//        //
//        // Summary:
//        //     Gets or sets the ID that the compiler will use when reporting a use of the API.
//        //
//        //
//        // Returns:
//        //     The unique diagnostic ID.
//        public string? DiagnosticId { get; set; }
//        //
//        // Summary:
//        //     Gets a value that indicates whether the compiler will treat usage of the obsolete
//        //     program element as an error.
//        //
//        // Returns:
//        //     true if the obsolete element usage is considered an error; otherwise, false.
//        //     The default is false.
//        public bool IsError { get; }
//        //
//        // Summary:
//        //     Gets the workaround message.
//        //
//        // Returns:
//        //     The workaround text string.
//        public string? Message { get; }
//        //
//        // Summary:
//        //     Gets or sets the URL for corresponding documentation. The API accepts a format
//        //     string instead of an actual URL, creating a generic URL that includes the diagnostic
//        //     ID.
//        //
//        // Returns:
//        //     The format string that represents a URL to corresponding documentation.
//        public string? UrlFormat { get; set; }
//    }
//}
