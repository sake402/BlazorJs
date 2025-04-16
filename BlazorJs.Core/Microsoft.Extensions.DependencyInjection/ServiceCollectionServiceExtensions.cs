using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using BlazorJs.Core;

namespace Microsoft.Extensions.DependencyInjection
{
    //
    // Summary:
    //     Extension methods for adding services to an Microsoft.Extensions.DependencyInjection.IServiceCollection.
    public static partial class ServiceCollectionServiceExtensions
    {
        //
        // Summary:
        //     Adds a transient service of the type specified in serviceType with an implementation
        //     of the type specified in implementationType to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceType:
        //     The type of the service to register.
        //
        //   implementationType:
        //     The implementation type of the service.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddTransient(this IServiceCollection services, Type serviceType, Type implementationType)
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(implementationType, "implementationType");
            return Add(services, serviceType, implementationType, ServiceLifetime.Transient);
        }

        //
        // Summary:
        //     Adds a transient service of the type specified in serviceType with a factory
        //     specified in implementationFactory to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceType:
        //     The type of the service to register.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddTransient(this IServiceCollection services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return Add(services, serviceType, implementationFactory, ServiceLifetime.Transient);
        }

        //
        // Summary:
        //     Adds a transient service of the type specified in TService with an implementation
        //     type specified in TImplementation to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        //   TImplementation:
        //     The type of the implementation to use.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection services) where TService : class where TImplementation : class, TService
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            return services.AddTransient(typeof(TService), typeof(TImplementation));
        }

        //
        // Summary:
        //     Adds a transient service of the type specified in serviceType to the specified
        //     Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceType:
        //     The type of the service to register and the implementation to use.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddTransient(this IServiceCollection services, Type serviceType)
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            return services.AddTransient(serviceType, serviceType);
        }

        //
        // Summary:
        //     Adds a transient service of the type specified in TService to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddTransient<TService>(this IServiceCollection services) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            return services.AddTransient(typeof(TService));
        }

        //
        // Summary:
        //     Adds a transient service of the type specified in TService with a factory specified
        //     in implementationFactory to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddTransient<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return services.AddTransient(typeof(TService), (sp) => implementationFactory(sp));
        }

        //
        // Summary:
        //     Adds a transient service of the type specified in TService with an implementation
        //     type specified in TImplementation using the factory specified in implementationFactory
        //     to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        //   TImplementation:
        //     The type of the implementation to use.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return services.AddTransient(typeof(TService), (sp) => implementationFactory(sp));
        }

        //
        // Summary:
        //     Adds a scoped service of the type specified in serviceType with an implementation
        //     of the type specified in implementationType to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceType:
        //     The type of the service to register.
        //
        //   implementationType:
        //     The implementation type of the service.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddScoped(this IServiceCollection services, Type serviceType, Type implementationType)
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(implementationType, "implementationType");
            return Add(services, serviceType, implementationType, ServiceLifetime.Scoped);
        }

        //
        // Summary:
        //     Adds a scoped service of the type specified in serviceType with a factory specified
        //     in implementationFactory to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceType:
        //     The type of the service to register.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddScoped(this IServiceCollection services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return Add(services, serviceType, implementationFactory, ServiceLifetime.Scoped);
        }

        //
        // Summary:
        //     Adds a scoped service of the type specified in TService with an implementation
        //     type specified in TImplementation to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        //   TImplementation:
        //     The type of the implementation to use.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services) where TService : class where TImplementation : class, TService
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            return services.AddScoped(typeof(TService), typeof(TImplementation));
        }

        //
        // Summary:
        //     Adds a scoped service of the type specified in serviceType to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceType:
        //     The type of the service to register and the implementation to use.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddScoped(this IServiceCollection services, Type serviceType)
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            return services.AddScoped(serviceType, serviceType);
        }

        //
        // Summary:
        //     Adds a scoped service of the type specified in TService to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddScoped<TService>(this IServiceCollection services) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            return services.AddScoped(typeof(TService));
        }

        //
        // Summary:
        //     Adds a scoped service of the type specified in TService with a factory specified
        //     in implementationFactory to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddScoped<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return services.AddScoped(typeof(TService), (sp) => implementationFactory(sp));
        }

        //
        // Summary:
        //     Adds a scoped service of the type specified in TService with an implementation
        //     type specified in TImplementation using the factory specified in implementationFactory
        //     to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        //   TImplementation:
        //     The type of the implementation to use.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return services.AddScoped(typeof(TService), (sp) => implementationFactory(sp));
        }

        //
        // Summary:
        //     Adds a singleton service of the type specified in serviceType with an implementation
        //     of the type specified in implementationType to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceType:
        //     The type of the service to register.
        //
        //   implementationType:
        //     The implementation type of the service.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddSingleton(this IServiceCollection services, Type serviceType, Type implementationType)
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(implementationType, "implementationType");
            return Add(services, serviceType, implementationType, ServiceLifetime.Singleton);
        }

        //
        // Summary:
        //     Adds a singleton service of the type specified in serviceType with a factory
        //     specified in implementationFactory to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceType:
        //     The type of the service to register.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddSingleton(this IServiceCollection services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return Add(services, serviceType, implementationFactory, ServiceLifetime.Singleton);
        }

        //
        // Summary:
        //     Adds a singleton service of the type specified in TService with an implementation
        //     type specified in TImplementation to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        //   TImplementation:
        //     The type of the implementation to use.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddSingleton<TService, TImplementation>(this IServiceCollection services) where TService : class where TImplementation : class, TService
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            return services.AddSingleton(typeof(TService), typeof(TImplementation));
        }

        //
        // Summary:
        //     Adds a singleton service of the type specified in serviceType to the specified
        //     Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceType:
        //     The type of the service to register and the implementation to use.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddSingleton(this IServiceCollection services, Type serviceType)
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            return services.AddSingleton(serviceType, serviceType);
        }

        //
        // Summary:
        //     Adds a singleton service of the type specified in TService to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddSingleton<TService>(this IServiceCollection services) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            return services.AddSingleton(typeof(TService));
        }

        //
        // Summary:
        //     Adds a singleton service of the type specified in TService with a factory specified
        //     in implementationFactory to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddSingleton<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return services.AddSingleton(typeof(TService), implementationFactory);
        }

        //
        // Summary:
        //     Adds a singleton service of the type specified in TService with an implementation
        //     type specified in TImplementation using the factory specified in implementationFactory
        //     to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        //   TImplementation:
        //     The type of the implementation to use.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddSingleton<TService, TImplementation>(this IServiceCollection services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return services.AddSingleton(typeof(TService), implementationFactory);
        }

        //
        // Summary:
        //     Adds a singleton service of the type specified in serviceType with an instance
        //     specified in implementationInstance to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceType:
        //     The type of the service to register.
        //
        //   implementationInstance:
        //     The instance of the service.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddSingleton(this IServiceCollection services, Type serviceType, object implementationInstance)
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(implementationInstance, "implementationInstance");
            ServiceDescriptor item = new ServiceDescriptor(serviceType, implementationInstance);
            services.Add(item);
            return services;
        }

        //
        // Summary:
        //     Adds a singleton service of the type specified in TService with an instance specified
        //     in implementationInstance to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   implementationInstance:
        //     The instance of the service.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddSingleton<TService>(this IServiceCollection services, TService implementationInstance) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(implementationInstance, "implementationInstance");
            return services.AddSingleton(typeof(TService), implementationInstance);
        }

        private static IServiceCollection Add(IServiceCollection collection, Type serviceType, Type implementationType, ServiceLifetime lifetime)
        {
            ServiceDescriptor item = new ServiceDescriptor(serviceType, implementationType, lifetime);
            collection.Add(item);
            return collection;
        }

        private static IServiceCollection Add(IServiceCollection collection, Type serviceType, Func<IServiceProvider, object> implementationFactory, ServiceLifetime lifetime)
        {
            ServiceDescriptor item = new ServiceDescriptor(serviceType, implementationFactory, lifetime);
            collection.Add(item);
            return collection;
        }

        //
        // Summary:
        //     Adds a transient service of the type specified in serviceType with an implementation
        //     of the type specified in implementationType to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceType:
        //     The type of the service to register.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationType:
        //     The implementation type of the service.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedTransient(this IServiceCollection services, Type serviceType, object serviceKey, Type implementationType)
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(implementationType, "implementationType");
            return AddKeyed(services, serviceType, serviceKey, implementationType, ServiceLifetime.Transient);
        }

        //
        // Summary:
        //     Adds a transient service of the type specified in serviceType with a factory
        //     specified in implementationFactory to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceType:
        //     The type of the service to register.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedTransient(this IServiceCollection services, Type serviceType, object serviceKey, Func<IServiceProvider, object, object> implementationFactory)
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return AddKeyed(services, serviceType, serviceKey, implementationFactory, ServiceLifetime.Transient);
        }

        //
        // Summary:
        //     Adds a transient service of the type specified in TService with an implementation
        //     type specified in TImplementation to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        //   TImplementation:
        //     The type of the implementation to use.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedTransient<TService, TImplementation>(this IServiceCollection services, object serviceKey) where TService : class where TImplementation : class, TService
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            return services.AddKeyedTransient(typeof(TService), serviceKey, typeof(TImplementation));
        }

        //
        // Summary:
        //     Adds a transient service of the type specified in serviceType to the specified
        //     Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceType:
        //     The type of the service to register and the implementation to use.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedTransient(this IServiceCollection services, Type serviceType, object serviceKey)
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            return services.AddKeyedTransient(serviceType, serviceKey, serviceType);
        }

        //
        // Summary:
        //     Adds a transient service of the type specified in TService to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedTransient<TService>(this IServiceCollection services, object serviceKey) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            return services.AddKeyedTransient(typeof(TService), serviceKey);
        }

        //
        // Summary:
        //     Adds a transient service of the type specified in TService with a factory specified
        //     in implementationFactory to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedTransient<TService>(this IServiceCollection services, object serviceKey, Func<IServiceProvider, object, TService> implementationFactory) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return services.AddKeyedTransient(typeof(TService), serviceKey, (sp, key) => implementationFactory(sp, key));
        }

        //
        // Summary:
        //     Adds a transient service of the type specified in TService with an implementation
        //     type specified in TImplementation using the factory specified in implementationFactory
        //     to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        //   TImplementation:
        //     The type of the implementation to use.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedTransient<TService, TImplementation>(this IServiceCollection services, object serviceKey, Func<IServiceProvider, object, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return services.AddKeyedTransient(typeof(TService), serviceKey, (sp, key) => implementationFactory(sp, key));
        }

        //
        // Summary:
        //     Adds a scoped service of the type specified in serviceType with an implementation
        //     of the type specified in implementationType to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceType:
        //     The type of the service to register.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationType:
        //     The implementation type of the service.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedScoped(this IServiceCollection services, Type serviceType, object serviceKey, Type implementationType)
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(implementationType, "implementationType");
            return AddKeyed(services, serviceType, serviceKey, implementationType, ServiceLifetime.Scoped);
        }

        //
        // Summary:
        //     Adds a scoped service of the type specified in serviceType with a factory specified
        //     in implementationFactory to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceType:
        //     The type of the service to register.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedScoped(this IServiceCollection services, Type serviceType, object serviceKey, Func<IServiceProvider, object, object> implementationFactory)
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return AddKeyed(services, serviceType, serviceKey, implementationFactory, ServiceLifetime.Scoped);
        }

        //
        // Summary:
        //     Adds a scoped service of the type specified in TService with an implementation
        //     type specified in TImplementation to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        //   TImplementation:
        //     The type of the implementation to use.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedScoped<TService, TImplementation>(this IServiceCollection services, object serviceKey) where TService : class where TImplementation : class, TService
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            return services.AddKeyedScoped(typeof(TService), serviceKey, typeof(TImplementation));
        }

        //
        // Summary:
        //     Adds a scoped service of the type specified in serviceType to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceType:
        //     The type of the service to register and the implementation to use.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedScoped(this IServiceCollection services, Type serviceType, object serviceKey)
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            return services.AddKeyedScoped(serviceType, serviceKey, serviceType);
        }

        //
        // Summary:
        //     Adds a scoped service of the type specified in TService to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedScoped<TService>(this IServiceCollection services, object serviceKey) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            return services.AddKeyedScoped(typeof(TService), serviceKey);
        }

        //
        // Summary:
        //     Adds a scoped service of the type specified in TService with a factory specified
        //     in implementationFactory to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedScoped<TService>(this IServiceCollection services, object serviceKey, Func<IServiceProvider, object, TService> implementationFactory) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return services.AddKeyedScoped(typeof(TService), serviceKey, (sp, key) => implementationFactory(sp, key));
        }

        //
        // Summary:
        //     Adds a scoped service of the type specified in TService with an implementation
        //     type specified in TImplementation using the factory specified in implementationFactory
        //     to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        //   TImplementation:
        //     The type of the implementation to use.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedScoped<TService, TImplementation>(this IServiceCollection services, object serviceKey, Func<IServiceProvider, object, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return services.AddKeyedScoped(typeof(TService), serviceKey, (sp, key) => implementationFactory(sp, key));
        }

        //
        // Summary:
        //     Adds a singleton service of the type specified in serviceType with an implementation
        //     of the type specified in implementationType to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceType:
        //     The type of the service to register.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationType:
        //     The implementation type of the service.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedSingleton(this IServiceCollection services, Type serviceType, object serviceKey, Type implementationType)
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(implementationType, "implementationType");
            return AddKeyed(services, serviceType, serviceKey, implementationType, ServiceLifetime.Singleton);
        }

        //
        // Summary:
        //     Adds a singleton service of the type specified in serviceType with a factory
        //     specified in implementationFactory to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceType:
        //     The type of the service to register.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedSingleton(this IServiceCollection services, Type serviceType, object serviceKey, Func<IServiceProvider, object, object> implementationFactory)
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return AddKeyed(services, serviceType, serviceKey, implementationFactory, ServiceLifetime.Singleton);
        }

        //
        // Summary:
        //     Adds a singleton service of the type specified in TService with an implementation
        //     type specified in TImplementation to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        //   TImplementation:
        //     The type of the implementation to use.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedSingleton<TService, TImplementation>(this IServiceCollection services, object serviceKey) where TService : class where TImplementation : class, TService
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            return services.AddKeyedSingleton(typeof(TService), serviceKey, typeof(TImplementation));
        }

        //
        // Summary:
        //     Adds a singleton service of the type specified in serviceType to the specified
        //     Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceType:
        //     The type of the service to register and the implementation to use.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedSingleton(this IServiceCollection services, Type serviceType, object serviceKey)
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            return services.AddKeyedSingleton(serviceType, serviceKey, serviceType);
        }

        //
        // Summary:
        //     Adds a singleton service of the type specified in TService to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedSingleton<TService>(this IServiceCollection services, object serviceKey) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            return services.AddKeyedSingleton(typeof(TService), serviceKey, typeof(TService));
        }

        //
        // Summary:
        //     Adds a singleton service of the type specified in TService with a factory specified
        //     in implementationFactory to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedSingleton<TService>(this IServiceCollection services, object serviceKey, Func<IServiceProvider, object, TService> implementationFactory) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return services.AddKeyedSingleton(typeof(TService), serviceKey, implementationFactory);
        }

        //
        // Summary:
        //     Adds a singleton service of the type specified in TService with an implementation
        //     type specified in TImplementation using the factory specified in implementationFactory
        //     to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service to add.
        //
        //   TImplementation:
        //     The type of the implementation to use.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedSingleton<TService, TImplementation>(this IServiceCollection services, object serviceKey, Func<IServiceProvider, object, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return services.AddKeyedSingleton(typeof(TService), serviceKey, implementationFactory);
        }

        //
        // Summary:
        //     Adds a singleton service of the type specified in serviceType with an instance
        //     specified in implementationInstance to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceType:
        //     The type of the service to register.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationInstance:
        //     The instance of the service.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedSingleton(this IServiceCollection services, Type serviceType, object serviceKey, object implementationInstance)
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(implementationInstance, "implementationInstance");
            ServiceDescriptor item = new ServiceDescriptor(serviceType, serviceKey, implementationInstance);
            services.Add(item);
            return services;
        }

        //
        // Summary:
        //     Adds a singleton service of the type specified in TService with an instance specified
        //     in implementationInstance to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationInstance:
        //     The instance of the service.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddKeyedSingleton<TService>(this IServiceCollection services, object serviceKey, TService implementationInstance) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(services, "services");
            ThrowHelperExtension.ThrowIfNull(implementationInstance, "implementationInstance");
            return services.AddKeyedSingleton(typeof(TService), serviceKey, implementationInstance);
        }

        private static IServiceCollection AddKeyed(IServiceCollection collection, Type serviceType, object serviceKey, Type implementationType, ServiceLifetime lifetime)
        {
            ServiceDescriptor item = new ServiceDescriptor(serviceType, serviceKey, implementationType, lifetime);
            collection.Add(item);
            return collection;
        }

        private static IServiceCollection AddKeyed(IServiceCollection collection, Type serviceType, object serviceKey, Func<IServiceProvider, object, object> implementationFactory, ServiceLifetime lifetime)
        {
            ServiceDescriptor item = new ServiceDescriptor(serviceType, serviceKey, implementationFactory, lifetime);
            collection.Add(item);
            return collection;
        }
    }

}
