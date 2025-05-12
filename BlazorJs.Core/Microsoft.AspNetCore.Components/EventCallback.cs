using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlazorJs.Core;
using static H5.Core.dom;

namespace Microsoft.AspNetCore.Components
{
    public interface IEventCallback
    {
        EventCallbackFlags Flags { get; }
        Task InvokeAsync(Event eventData);
    }

    public partial struct EventCallback : IEventCallback
    {
        public static readonly EventCallbackFactory Factory = new EventCallbackFactory();

        EventCallback<object> internalCallback;

        public EventCallback(EventCallback<object> internalCallback)
        {
            this.internalCallback = internalCallback;
        }

        public Task InvokeAsync()
        {
            return internalCallback.InvokeAsync(null);
        }

        Task IEventCallback.InvokeAsync(Event eventData)
        {
            return internalCallback.InvokeAsync(eventData);
        }

        public object Receiver => internalCallback.Receiver;
        public Delegate Delegate => internalCallback.Delegate;
        public bool HasDelegate => internalCallback.HasDelegate;
        public EventCallbackFlags Flags => internalCallback.Flags;
    }
    public partial struct EventCallback<T> : IEventCallback
    {
        public object Receiver { get; }
        public MulticastDelegate Delegate { get; }
        EventCallbackDelegateType type;
        public EventCallbackFlags Flags { get; }

        internal EventCallback(object receiver, MulticastDelegate target, EventCallbackDelegateType type, EventCallbackFlags eventFlags)
        {
            Receiver = receiver;
            Delegate = target;
            this.type = type;
            Flags = eventFlags;
        }

        internal EventCallback(object receiver, Action<T> target, EventCallbackFlags eventFlags) : this(receiver, target, EventCallbackDelegateType.ActionT, eventFlags)
        {
        }

        internal EventCallback(object receiver, Func<T, Task> target, EventCallbackFlags eventFlags) : this(receiver, target, EventCallbackDelegateType.FuncTTask, eventFlags)
        {
        }

        Task Callback(object _eventData)
        {
            Task task = Task.CompletedTask;
            switch (type)
            {
                case EventCallbackDelegateType.Action:
                    Delegate.Call();
                    break;
                case EventCallbackDelegateType.FuncTask:
                    task = (Task)Delegate.Call();
                    break;
                case EventCallbackDelegateType.ActionT:
                    Delegate.Call(null, _eventData);
                    break;
                case EventCallbackDelegateType.FuncTTask:
                    task = (Task)Delegate.Call(null, _eventData);
                    break;
            }
            return task;
        }

        Task IEventCallback.InvokeAsync(Event eventData)
        {
            return InvokeAsync(eventData);
        }

        public async Task InvokeAsync(object eventData)
        {
            if (Delegate != null)
            {
                var scope = Receiver ?? Delegate["$scope"];
                if (scope is IHandleEvent he)
                {
                    await he.HandleEventAsync(new EventCallbackWorkItem(Delegate), eventData);
                }
                else
                {
                    await Callback(eventData);
                }
            }
        }

        public Task InvokeAsync(T eventData)
        {
            return InvokeAsync((object)eventData);
        }

        public bool HasDelegate => Delegate != null;
    }
}
