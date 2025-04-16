namespace Microsoft.AspNetCore.Components
{
    public partial struct MarkupString
    {
        public MarkupString(string html)
        {
            Html = html;
        }

        public string Html { get; set; }

        public static implicit operator MarkupString(string str) => new MarkupString(str);
    }
}
