namespace BlazorJs.Compiler.Razor
{
    public class RazorLayout
    {
        public RazorLayout(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override string ToString()
        {
            return $"@layout {Name}";
        }
    }
}
