using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components.RenderTree;

namespace Microsoft.AspNetCore.Components
{
    public abstract partial class ComponentBase : IComponent, IHandleEvent, IHandleAfterRender, IDisposable
    {
        public virtual string ShadowName => GetType().Name;

        private readonly RenderFragment _renderFragment;

        private RenderHandle _renderHandle;

        private bool _initialized;

        private bool _hasNeverRendered = true;

        private bool _hasPendingQueuedRender;

        private bool _hasCalledOnAfterRender;

        public ComponentBase()
        {
            _renderFragment = (IUIFrame builder, object key) =>
            {
                _hasPendingQueuedRender = false;
                _hasNeverRendered = false;
                BuildRenderTree(builder);
            };
        }

        //
        // Summary:
        //     Executes the supplied work item on the associated renderer's synchronization
        //     context.
        //
        // Parameters:
        //   workItem:
        //     The work item to execute.
        protected Task InvokeAsync(Action workItem)
        {
            return _renderHandle.Dispatcher.InvokeAsync(workItem);
        }

        //
        // Summary:
        //     Executes the supplied work item on the associated renderer's synchronization
        //     context.
        //
        // Parameters:
        //   workItem:
        //     The work item to execute.
        protected Task InvokeAsync(Func<Task> workItem)
        {
            return _renderHandle.Dispatcher.InvokeAsync(workItem);
        }

        //make razor generator happy
        protected virtual void BuildRenderTree(RenderTreeBuilder builder)
        {
        }

        protected internal virtual void BuildRenderTree(IUIFrame frame, object key = null)
        {
        }

        //public void Build(object key)
        //{
        //    State.TrackContents(() =>
        //    {
        //        BuildRenderTree(this, key);
        //    });
        //}

        protected internal virtual void InjectServices(IServiceProvider provider)
        {
        }

        protected internal virtual void CascadeParameters()
        {

        }

        protected internal virtual void OnInitialized()
        {
        }

        protected internal virtual Task OnInitializedAsync()
        {
            return Task.CompletedTask;
        }

        protected internal virtual void OnParametersSet()
        {
        }

        protected internal virtual Task OnParametersSetAsync()
        {
            return Task.CompletedTask;
        }

        protected internal virtual void OnAfterRender(bool firstRender)
        {
        }

        protected internal virtual Task OnAfterRenderAsync(bool firstRender)
        {
            return Task.CompletedTask;
        }

        protected internal virtual bool HandleError(Exception exception, ComponentLifeCycle lifeCycle)
        {
            return false;
        }

        internal void WithErrorHandling(Action<ComponentBase> action, ComponentLifeCycle lifeCycle)
        {
            if (isDisposed)
                return;
            try
            {
                action(this);
            }
            catch (Exception e)
            {
                var handled = HandleError(e, lifeCycle);
                if (!handled)
                    throw;
            }
        }

        protected void RequestCascadingParameter<T>(Action<T> action, string cascadingParameterName = null)
        {
            var renderer = (BrowserNativeRenderer)_renderHandle._renderer;
            var state = renderer.GetRequiredState(_renderHandle._componentId);
            DisposeOnDispose(state.SubscribeCascadingValue<T>((o, e) => action(e), cascadingParameterName));
        }

        public void Set(string key, object value)
        {
            if (key == "@attributes")
            {
                if (value is IReadOnlyDictionary<string, object> dic)
                {
                    foreach (var kv in dic)
                    {
                        this.SetValue(kv.Key, kv.Value);
                    }
                }
                else
                {
                    foreach (var mkey in object.GetOwnPropertyNames(value))
                    {
                        if (mkey.Length > 0 && char.IsLower(mkey[0]))
                        {
                            var val = value[mkey];
                            this.SetValue(mkey, val);
                        }
                    }
                }
            }
            else
            {
                if (key.Length > 0 && char.IsLower(key[0]))
                {
                    this.SetValue(key, value);
                }
            }
        }

        public event EventHandler OnDisposed;
        protected void DisposeOnDispose(IDisposable disposable)
        {
            if (disposable != null)
                OnDisposed += (s, e) => disposable.Dispose();
        }

        bool isDisposed;
        public virtual void Dispose()
        {
            if (isDisposed)
                return;
            //var renderer = (BrowserNativeRenderer)_renderHandle._renderer;
            //var state = renderer.GetState(_renderHandle._componentId);
            //state?.Dispose();
            OnDisposed?.Invoke(this, EventArgs.Empty);
            isDisposed = true;
        }

        //
        // Summary:
        //     Returns a flag to indicate whether the component should render.
        protected virtual bool ShouldRender()
        {
            return true;
        }

        //
        // Summary:
        //     Notifies the component that its state has changed. When applicable, this will
        //     cause the component to be re-rendered.
        protected void StateHasChanged()
        {
            if (isDisposed)
                return;
            if (_hasPendingQueuedRender || (!_hasNeverRendered && !ShouldRender() && !_renderHandle.IsRenderingOnMetadataUpdate))
            {
                return;
            }

            _hasPendingQueuedRender = true;
            try
            {
                _renderHandle.Render(_renderFragment);
            }
            catch
            {
                _hasPendingQueuedRender = false;
                throw;
            }
        }

        //
        // Summary:
        //     Treats the supplied exception as being thrown by this component. This will cause
        //     the enclosing ErrorBoundary to transition into a failed state. If there is no
        //     enclosing ErrorBoundary, it will be regarded as an exception from the enclosing
        //     renderer. This is useful if an exception occurs outside the component lifecycle
        //     methods, but you wish to treat it the same as an exception from a component lifecycle
        //     method.
        //
        // Parameters:
        //   exception:
        //     The System.Exception that will be dispatched to the renderer.
        //
        // Returns:
        //     A System.Threading.Tasks.Task that will be completed when the exception has finished
        //     dispatching.
        protected Task DispatchExceptionAsync(Exception exception)
        {
            return _renderHandle.DispatchExceptionAsync(exception);
        }

        public void Attach(RenderHandle renderHandle)
        {
            if (_renderHandle.IsInitialized)
            {
                throw new InvalidOperationException("The render handle is already set. Cannot initialize a ComponentBase more than once.");
            }
            _renderHandle = renderHandle;
        }

        //
        // Summary:
        //     Sets parameters supplied by the component's parent in the render tree.
        //
        // Parameters:
        //   parameters:
        //     The parameters.
        //
        // Returns:
        //     A System.Threading.Tasks.Task that completes when the component has finished
        //     updating and rendering itself.
        //
        // Remarks:
        //     Parameters are passed when Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync(Microsoft.AspNetCore.Components.ParameterView)
        //     is called. It is not required that the caller supply a parameter value for all
        //     of the parameters that are logically understood by the component.
        //
        //     The default implementation of Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync(Microsoft.AspNetCore.Components.ParameterView)
        //     will set the value of each property decorated with Microsoft.AspNetCore.Components.ParameterAttribute
        //     or Microsoft.AspNetCore.Components.CascadingParameterAttribute that has a corresponding
        //     value in the Microsoft.AspNetCore.Components.ParameterView. Parameters that do
        //     not have a corresponding value will be unchanged.
        public virtual Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);
            if (!_initialized)
            {
                _initialized = true;
                return RunInitAndSetParametersAsync();
            }

            return CallOnParametersSetAsync();
        }

        private async Task RunInitAndSetParametersAsync()
        {
            WithErrorHandling((icomponent) =>
            {
                OnInitialized();
            }, ComponentLifeCycle.OnInitializing);
            Task task = Task.CompletedTask;
            WithErrorHandling((icomponent) =>
            {
                task = OnInitializedAsync();
            }, ComponentLifeCycle.OnInitializingAsync);
            if (task.Status != TaskStatus.RanToCompletion && task.Status != TaskStatus.Canceled)
            {
                StateHasChanged();
                try
                {
                    await task;
                }
                catch
                {
                    if (!task.IsCanceled)
                    {
                        throw;
                    }
                }
            }

            await CallOnParametersSetAsync();
        }

        private Task CallOnParametersSetAsync()
        {
            WithErrorHandling((icomponent) =>
            {
                OnParametersSet();
            }, ComponentLifeCycle.OnParametersSetting);
            Task task = Task.CompletedTask;
            WithErrorHandling((icomponent) =>
            {
                task = OnParametersSetAsync();
            }, ComponentLifeCycle.OnParametersSettingAsnc);
            bool num = task.Status != TaskStatus.RanToCompletion && task.Status != TaskStatus.Canceled;
            StateHasChanged();
            if (!num)
            {
                return Task.CompletedTask;
            }

            return CallStateHasChangedOnAsyncCompletion(task);
        }

        private async Task CallStateHasChangedOnAsyncCompletion(Task task)
        {
            try
            {
                await task;
            }
            catch
            {
                if (task.IsCanceled)
                {
                    return;
                }

                throw;
            }

            StateHasChanged();
        }


        Task IHandleEvent.HandleEventAsync(EventCallbackWorkItem callback, object arg)
        {
            Task task = callback.InvokeAsync(arg);
            bool num = task.Status != TaskStatus.RanToCompletion && task.Status != TaskStatus.Canceled;
            StateHasChanged();
            if (!num)
            {
                return Task.CompletedTask;
            }

            return CallStateHasChangedOnAsyncCompletion(task);
        }

        Task IHandleAfterRender.OnAfterRenderAsync()
        {
            bool firstRender = !_hasCalledOnAfterRender;
            _hasCalledOnAfterRender = true;
            WithErrorHandling((icomponent) =>
            {
                icomponent.OnAfterRender(firstRender);
            }, ComponentLifeCycle.OnAfterRender);
            Task task = Task.CompletedTask; ;
            WithErrorHandling((icomponent) =>
            {
                task = OnAfterRenderAsync(firstRender);
            }, ComponentLifeCycle.OnAfterRenderAsnyc);
            return task;
        }


        public override string ToString()
        {
            var renderer = (BrowserNativeRenderer)_renderHandle._renderer;
            var state = renderer.GetState(_renderHandle._componentId);
            return state?.ToString() ?? base.ToString();
        }
    }
}
