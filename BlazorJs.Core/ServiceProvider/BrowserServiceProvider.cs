using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorJs.ServiceProvider
{
    internal partial class BrowserServiceProvider : List<ServiceDescriptor>, IServiceProvider, IServiceCollection
    {
        //List<ServiceDescriptor> serviceDescriptors = new List<ServiceDescriptor>();

        List<IServiceResolver> _resolvers = new List<IServiceResolver>();
        Dictionary<(Type, object), object> _resolvedServices = new Dictionary<(Type, object), object>();

        internal BrowserServiceProvider()
        {
            _resolvers.Add(new ServiceCollectionResolver(this));
        }

        object ResolveSingle(Type serviceType, object serviceKey, ServiceLifetime currentScope)
        {
            foreach (var _resolver in _resolvers)
            {
                var service = _resolver.TryResolve(this, serviceType, serviceKey, false, currentScope);
                if (service != null)
                    return service;
            }
            return null;
        }

        //MethodInfo? castToServiceType;
        IEnumerable<object> ResolveMany(Type serviceType, object serviceKey, ServiceLifetime currentScope)
        {
            List<object> services = new List<object>();
            foreach (var _resolver in _resolvers)
            {
                var service = _resolver.TryResolve(this, serviceType, serviceKey, true, currentScope);
                if (service != null)
                    services.AddRange((IEnumerable<object>)service);
            }
            var castToServiceType = typeof(Enumerable)
               .GetMethod("Cast")
               .MakeGenericMethod(serviceType);
            var resolvedServices = castToServiceType.Invoke(null, new object[] { services });
            //var toList = typeof(Enumerable)
            //    .GetMethod("ToList")!
            //    .MakeGenericMethod(serviceType)
            //    .Invoke(null, new object[] { castToServiceType })!;
            return (IEnumerable<object>)resolvedServices;
        }

        internal object Resolve(Type serviceType, object serviceKey, ServiceLifetime currentScope)
        {
            //if (serviceType.IsGenericType && serviceType.ImplementsOpenGeneric)
            if (serviceType.IsGenericType &&
                serviceType.GetGenericTypeDefinition() == typeof(IEnumerable<>) &&
                true
                /*serviceType.IsEnumerable(out var innerType)*/)
            {
                var innerType = serviceType.GetGenericArguments()[0];
                return ResolveMany(innerType, serviceKey, currentScope);
            }
            return ResolveSingle(serviceType, serviceKey, currentScope);
        }

        object GetServiceInternal(Type serviceType, object serviceKey)
        {
            lock (this)
            {
                if (_resolvedServices.TryGetValue((serviceType, serviceKey), out var service))
                    return service;
                service = Resolve(serviceType, serviceKey, ServiceLifetime.Singleton);
                if (service != null)
                    _resolvedServices.Add((serviceType, serviceKey), service);
                return service;
            }
        }

        public object GetService(Type serviceType)
        {
            return GetServiceInternal(serviceType, null);
        }

        public object GetKeyedService(Type serviceType, object serviceKey)
        {
            return GetServiceInternal(serviceType, serviceKey);
        }

        public object GetRequiredKeyedService(Type serviceType, object serviceKey)
        {
            return GetServiceInternal(serviceType, serviceKey) ?? throw new InvalidOperationException($"Cannot resolve {serviceType.FullName}");
        }
    }
}
