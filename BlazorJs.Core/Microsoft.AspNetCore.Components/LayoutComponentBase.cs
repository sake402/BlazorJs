namespace Microsoft.AspNetCore.Components
{
    public abstract partial class LayoutComponentBase : ComponentBase, ILayoutComponent
    {
        [Parameter] public RenderFragment Body { get; set; }
    }
}
