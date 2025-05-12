using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.AspNetCore.Components.RenderTree
{
    public abstract partial class Renderer
    {
        protected internal virtual ResourceAssetCollection Assets { get; } = ResourceAssetCollection.Empty;
        public abstract Dispatcher Dispatcher { get; }
        //renderer is never disposed
        public bool Disposed => false;
        protected internal virtual IComponentRenderMode GetComponentRenderMode(IComponent component) => null;
        internal IComponentRenderMode GetComponentRenderMode(int componentId) => null;
        protected internal virtual RendererInfo RendererInfo { get; }
        internal abstract void AddToRenderQueue(int componentId, RenderFragment renderFragment);
        internal abstract void HandleComponentException(Exception exception, int componentId);
        protected virtual void HandleException(Exception exception) { }
    }
}
