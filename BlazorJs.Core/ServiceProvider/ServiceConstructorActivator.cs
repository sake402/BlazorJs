using System.Reflection;
using System.Linq;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorJs.ServiceProvider
{
    internal partial class ServiceConstructorActivator : ServiceInstanceActivator
    {
        Type implementationType;
        ConstructorInfo constructor;
        object serviceKey;
        public ServiceConstructorActivator(ServiceDescriptor descriptor, Type serviceType, object serviceKey, IServiceProvider serviceProvider) : base(descriptor)
        {
            implementationType = descriptor.IsKeyedService ?
                descriptor.KeyedImplementationType :
                descriptor.ImplementationType;
            if (implementationType.IsGenericTypeDefinition && serviceType.IsGenericType)
            {
                var args = serviceType.GetGenericArguments();
                implementationType = implementationType.MakeGenericType(args);
            }
            var constructors = implementationType.GetConstructors(/*BindingFlags.Instance | BindingFlags.Public*/);
            if (constructors.Length == 0)
            {
                throw new InvalidOperationException($"No public constructor is defined on {implementationType.Name}");
            }
            else if (constructors.Length > 1)
            {
                int maxW = 0;
                foreach (var c in constructors)
                {
                    var w = 0;
                    var parameters = c.GetParameters();
                    if (parameters.All(p =>
                    {
                        return ((IServiceCollection)serviceProvider).GetServiceDescriptors(p.ParameterType, null).Any();
                    }))
                    {
                        var parametersCount = parameters.Length;
                        w = parametersCount;
                    }
                    if (w > maxW)
                    {
                        constructor = c;
                        maxW = w;
                    }
                }
                if (constructor == null)
                    throw new InvalidOperationException($"No constructor on {serviceType.FullName} can be used to instatiate it from the container");
            }
            else
            {
                constructor = constructors[0];
            }
            //var _delagate =Delegate.CreateDelegate(implementationType, constructor.met);
            this.serviceKey = serviceKey;
        }

        public override object Activate(IServiceProvider serviceProvider)
        {
            var types = constructor.GetParameters();
            var parameters = types.Select(t =>
            {
                //if this is a keyed service, try resolve it dependecies using the same key first,
                //then fallback to no key if not found
                if (serviceKey != null)
                {
                    var service = serviceProvider.GetKeyedService(t.ParameterType, serviceKey);
                    if (service != null)
                        return service;
                }
                return serviceProvider.GetRequiredService(t.ParameterType);
            }).ToArray();
            return constructor.Invoke(parameters);
            //return Activator.CreateInstance(implementationType, parameters);
        }
    }
}
