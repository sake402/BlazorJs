using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Components
{
    //
    // Summary:
    //     Interface implemented by components that receive notification that they have
    //     been rendered.
    public interface IHandleAfterRender
    {
        //
        // Summary:
        //     Notifies the component that it has been rendered.
        //
        // Returns:
        //     A System.Threading.Tasks.Task that represents the asynchronous event handling
        //     operation.
        Task OnAfterRenderAsync();
    }
}
