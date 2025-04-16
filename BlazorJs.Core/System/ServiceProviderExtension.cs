using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static partial class ServiceProviderExtension
    {
        public static T GetService<T>(this IServiceProvider provider)
        {
            return (T)provider.GetService(typeof(T));
        }

        public static object GetRequiredService(this IServiceProvider provider, Type type)
        {
            var t = provider.GetService(type);
            if (t == null)
            {
                throw new InvalidOperationException($"Cannot resolve service of type {type.FullName}");
            }
            return t;
        }

        public static T GetRequiredService<T>(this IServiceProvider provider)
        {
            var t = (T)provider.GetService(typeof(T));
            if (t == null)
            {
                throw new InvalidOperationException($"Cannot resolve service of type {typeof(T).FullName}");
            }
            return t;
        }

        public static IEnumerable<ServiceDescriptor> GetServiceDescriptors(this IServiceCollection services, Type serviceType, object serviceKey)
        {
            var descriptors = services.Where(s => s.ServiceType == serviceType && (s.ServiceKey == serviceKey || (s.ServiceKey?.Equals(serviceKey) ?? false)));
            if (serviceType.IsGenericType)
            {
                var openGenericType = serviceType.GetGenericTypeDefinition();
                var _descriptors = services.Where(s => s.ServiceType == openGenericType);
                descriptors = descriptors.Concat(_descriptors);
            }
            return descriptors;
        }

        public static void Match(this IServiceCollection services, Type serviceType, object serviceKey, Action<ServiceDescriptor> action)
        {
            var openGenericType = serviceType.IsGenericType ? serviceType.GetGenericTypeDefinition() : null;
            for (int i = 0; i < services.Count; i++)
            {
                var service = services[i];
                if (service.ServiceType == serviceType || openGenericType != null && service.ServiceType == openGenericType)
                {
                    if (service.ServiceKey == serviceKey || (service.ServiceKey?.Equals(serviceKey) ?? false))
                    {
                        action(service);
                    }
                }
            }
        }
    }
}
