using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Json
{
    public partial class JsonSerializerOptions
    {
        public static readonly JsonSerializerOptions Web = new JsonSerializerOptions();
        public JsonCommentHandling ReadCommentHandling { get; set; }
    }
}
