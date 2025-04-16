namespace Microsoft.AspNetCore.Components
{
    public partial interface ILayoutComponent : IComponent
    {
        RenderFragment Body { get; set; }
    }
}
