using System;

namespace BlazorJs.ServiceProvider
{
    internal partial class ServiceInstanceInstanceActivator : ServiceInstanceActivator
    {
        public ServiceInstanceInstanceActivator(ServiceDescriptor descriptor) : base(descriptor)
        {
        }

        public override object Activate(IServiceProvider serviceProvider)
        {
            if (Descriptor.IsKeyedService)
                return Descriptor.KeyedImplementationInstance;
            else
                return Descriptor.ImplementationInstance;
        }
    }
}
