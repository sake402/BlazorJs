using System;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Components
{
    /// <summary>
    /// Wraps a callback delegate associated with an event.
    /// </summary>
    public readonly struct EventCallbackWorkItem
    {
        /// <summary>
        /// An empty <see cref="EventCallbackWorkItem"/>.
        /// </summary>
        public static readonly EventCallbackWorkItem Empty = new EventCallbackWorkItem(null);

        private readonly MulticastDelegate _delegate;

        /// <summary>
        /// Creates a new <see cref="EventCallbackWorkItem"/> with the provided <paramref name="delegate"/>.
        /// </summary>
        /// <param name="delegate">The callback delegate.</param>
        public EventCallbackWorkItem(MulticastDelegate @delegate)
        {
            _delegate = @delegate;
        }

        /// <summary>
        /// Invokes the delegate associated with this <see cref="EventCallbackWorkItem"/>.
        /// </summary>
        /// <param name="arg">The argument to provide to the delegate. May be <c>null</c>.</param>
        /// <returns>A <see cref="Task"/> then will complete asynchronously once the delegate has completed.</returns>
        public Task InvokeAsync(object arg)
        {
            return InvokeAsync<object>(_delegate, arg);
        }

        internal static Task InvokeAsync<T>(MulticastDelegate @delegate, T arg)
        {
            switch (@delegate)
            {
                case null:
                    return Task.CompletedTask;

                //rearrange the order of case from more specific Func<T, Task> to generic Action
                //All this are designated as Function in javascript anyway, make sure the arg is passed

                //there is no guarantee that anything is returned though if we happen to call an action, so we make sure we return a task
                case Func<T, Task> funcEventArgs:
                    return funcEventArgs.Invoke(arg) ?? Task.CompletedTask;

                case Func<Task> func:
                    return func.Invoke() ?? Task.CompletedTask;

                case Action<T> actionEventArgs:
                    actionEventArgs.Invoke(arg);
                    return Task.CompletedTask;

                case Action action:
                    action.Invoke();
                    return Task.CompletedTask;


                default:
                    {
                        try
                        {
                            return @delegate.Call(arg) as Task ?? Task.CompletedTask;
                        }
                        catch (TargetInvocationException e)
                        {
                            // Since we fell into the DynamicInvoke case, any exception will be wrapped
                            // in a TIE. We can expect this to be thrown synchronously, so it's low overhead
                            // to unwrap it.
                            throw e.InnerException;
                            //return Task.FromException(e.InnerException!);
                        }
                    }
            }
        }
    }
}
