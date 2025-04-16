namespace System.Text.Json
{
    public struct JsonElement
    {
        internal object Object { get; }
        public JsonElement(object obj)
        {
            Object = obj;
            if (obj == null)
                ValueKind = JsonValueKind.Null;
        }
        public JsonValueKind ValueKind { get; }
        public bool TryGetProperty(string path, out JsonElement element)
        {
            var o = Object[path];
            if (o != null)
            {
                element = new JsonElement(o);
                return true;
            }
            element = default;
            return false;
        }
    }
}
