using System;

namespace BlazorJs.ServiceProvider
{
    internal partial class ServiceFactoryInstanceActivator : ServiceInstanceActivator
    {
        public ServiceFactoryInstanceActivator(ServiceDescriptor descriptor) : base(descriptor)
        {
        }

        public override object Activate(IServiceProvider serviceProvider)
        {
            if (Descriptor.IsKeyedService)
                return Descriptor.KeyedImplementationFactory(serviceProvider, Descriptor.ServiceKey);
            else
                return Descriptor.ImplementationFactory(serviceProvider);
        }
    }
}
