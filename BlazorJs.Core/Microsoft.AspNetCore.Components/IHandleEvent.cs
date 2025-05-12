using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Components
{
    //
    // Summary:
    //     Interface implemented by components that receive notification of state changes.
    public interface IHandleEvent
    {
        //
        // Summary:
        //     Notifies the a state change has been triggered.
        //
        // Parameters:
        //   item:
        //     The Microsoft.AspNetCore.Components.EventCallbackWorkItem associated with this
        //     event.
        //
        //   arg:
        //     The argument associated with this event.
        //
        // Returns:
        //     A System.Threading.Tasks.Task that completes once the component has processed
        //     the state change.
        Task HandleEventAsync(EventCallbackWorkItem item, object arg);
    }
}
