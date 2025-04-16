using System.Collections.Generic;
using System.Text;
using System.Linq;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorJs.ServiceProvider
{
    internal partial class ServiceCollectionResolver : IServiceResolver
    {
        IServiceCollection _services;
        Dictionary<(Type, object), Dictionary<ServiceDescriptor, ServiceInstanceActivator>> _activators = new Dictionary<(Type, object), Dictionary<ServiceDescriptor, ServiceInstanceActivator>>();
        public ServiceCollectionResolver(IServiceCollection services)
        {
            _services = services;
        }

        Dictionary<ServiceDescriptor, ServiceInstanceActivator> GetActivators(Type serviceType, object serviceKey, IServiceProvider serviceProvider)
        {
            if (!_activators.TryGetValue((serviceType, serviceKey), out var activatorsForSeviceDescriptors))
            {
                activatorsForSeviceDescriptors = new Dictionary<ServiceDescriptor, ServiceInstanceActivator>();
                _activators[(serviceType, serviceKey)] = activatorsForSeviceDescriptors;
                _services.Match(serviceType, serviceKey, (descriptor) =>
                {
                    if (!activatorsForSeviceDescriptors.TryGetValue(descriptor, out var activator))
                    {
                        ServiceInstanceActivator instanceActivator = null;
                        if (descriptor.IsKeyedService && descriptor.KeyedImplementationFactory != null ||
                           !descriptor.IsKeyedService && descriptor.ImplementationFactory != null)
                        {
                            instanceActivator = new ServiceFactoryInstanceActivator(descriptor);
                        }
                        else if (descriptor.IsKeyedService && descriptor.KeyedImplementationInstance != null ||
                                !descriptor.IsKeyedService && descriptor.ImplementationInstance != null)
                        {
                            instanceActivator = new ServiceInstanceInstanceActivator(descriptor);
                        }
                        else if (descriptor.IsKeyedService && descriptor.KeyedImplementationType != null ||
                                !descriptor.IsKeyedService && descriptor.ImplementationType != null)
                        {
                            instanceActivator = new ServiceConstructorActivator(descriptor, serviceType, serviceKey, serviceProvider);
                        }
                        else
                        {
                            throw new InvalidOperationException("Unknown Error");
                        }
                        activatorsForSeviceDescriptors[descriptor] = instanceActivator;
                    }
                });
            }
            return activatorsForSeviceDescriptors;
        }

        public object TryResolve(
            IServiceProvider serviceProvider,
            Type serviceType,
            object serviceKey,
            bool all,
            ServiceLifetime currentScope)
        {
            lock (this)
            {
                var activatorsForType = GetActivators(serviceType, serviceKey, serviceProvider);
                //foreach (var descriptor in _services.GetServiceDescriptors(type))
                //{
                //    if (!activatorsForType.TryGetValue(descriptor, out var activator))
                //    {
                //        ServiceInstanceActivator? instanceActivator = null;
                //        if (descriptor.ImplementationFactory != null)
                //        {
                //            instanceActivator = new ServiceFactoryInstanceActivator(descriptor);
                //        }
                //        else if (descriptor.ImplementationInstance != null)
                //        {
                //            instanceActivator = new ServiceInstanceInstanceActivator(descriptor);
                //        }
                //        else if (descriptor.ImplementationType != null)
                //        {
                //            instanceActivator = new ServiceConstructorActivator(descriptor, type, serviceProvider);
                //        }
                //        else
                //        {
                //            throw new InvalidOperationException("Unknown Error");
                //        }
                //        activatorsForType[descriptor] = instanceActivator;
                //    }
                //}
                if (!activatorsForType.Any() && !all)
                {
                    return null;// Enumerable.Empty<ResolvedService>();
                    //throw new InvalidOperationException($"Type {type.FullName} is not registered");
                }
                if (all)
                {
                    //return activatorsForType.Select(a => new ResolvedService
                    //{
                    //    LifeTime = Convert(a.Value.Descriptor.Lifetime),
                    //    Service = a.Value.Activate(serviceProvider)
                    //});
                    return activatorsForType.Select(a => a.Value.Activate(serviceProvider));
                    //return typeof(Enumerable)
                    //    .GetMethod("Cast")!
                    //    .MakeGenericMethod(type)
                    //    .Invoke(null, new object[] { services });
                }
                else
                {
                    var activator = activatorsForType.First();
                    return activator.Value.Activate(serviceProvider);
                    //return new ResolvedService[]
                    //{
                    //    new ResolvedService
                    //    {
                    //        Service = activator.Value.Activate(serviceProvider),
                    //        LifeTime = Convert(activator.Key.Lifetime)
                    //    }
                    //};
                }
            }
        }
    }
}
