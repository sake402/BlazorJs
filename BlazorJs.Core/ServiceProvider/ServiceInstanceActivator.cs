using System;

namespace BlazorJs.ServiceProvider
{
    internal abstract partial class ServiceInstanceActivator
    {
        public ServiceDescriptor Descriptor { get; }
        public ServiceInstanceActivator(ServiceDescriptor descriptor)
        {
            Descriptor = descriptor;
        }

        public abstract object Activate(IServiceProvider serviceProvider);
    }
}
