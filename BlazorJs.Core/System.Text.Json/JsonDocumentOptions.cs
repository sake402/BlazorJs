using H5;

namespace System.Text.Json
{
    [ObjectLiteral]
    public class JsonDocumentOptions
    {
        public JsonCommentHandling CommentHandling { get; set; }
        public bool AllowTrailingCommas { get; set; }
    }
}
