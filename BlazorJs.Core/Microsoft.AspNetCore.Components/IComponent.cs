using H5;
using System.Threading.Tasks;
using BlazorJs.Core;

namespace Microsoft.AspNetCore.Components
{
    public partial interface IComponent : IUIContent
    {
        //void OnInitialized();
        //Task OnInitializedAsync();
        //void OnParametersSet();
        //Task OnParametersSetAsync();
        //void Attach(IRenderer renderer);
        void BuildRenderTree(IUIFrame context, object key = null);
    }
}
