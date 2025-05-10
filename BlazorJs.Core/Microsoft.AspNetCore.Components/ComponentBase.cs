using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorJs.Core;

namespace Microsoft.AspNetCore.Components
{
    public abstract partial class ComponentBase : IComponent, IUIFrame
    {
        public virtual string ShadowName => GetType().Name;

        public UIFrameState State { get; set; }

        //Set custom attribute
        //public object this[string name]
        //{
        //    set
        //    {

        //    }
        //}

        //Javascript is single threaded, no synchronization context
        protected Task InvokeAsync(Action action)
        {
            action();
            return Task.CompletedTask;
        }

        //make razor generator happy
        protected virtual void BuildRenderTree(RenderTreeBuilder builder)
        {
        }

        protected internal virtual void BuildRenderTree(IUIFrame frame, object key = null)
        {
        }

        void IComponent.BuildRenderTree(IUIFrame frame, object key)
        {
            State.TrackContents(() =>
            {
                BuildRenderTree(this, key);
            });
        }

        public void Build(object key)
        {
            State.TrackContents(() =>
            {
                BuildRenderTree(this, key);
            });
        }

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
            DisposeOnDispose(State.SubscribeCascadingValue<T>((o, e) => action(e), cascadingParameterName));
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
            State.Dispose();
            OnDisposed?.Invoke(this, EventArgs.Empty);
            isDisposed = true;
        }

        public void StateHasChanged()
        {
            if (isDisposed)
                return;
            this.Render();
        }

        public override string ToString()
        {
            return State?.ToString() ?? base.ToString();
        }

        internal bool hasRendered;
    }
}
