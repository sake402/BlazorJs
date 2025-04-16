using System.Collections.Generic;
using BlazorJs.Core;

namespace System
{
    public partial class ServiceDescriptor
    {
        private Type _implementationType;

        private object _implementationInstance;

        private object _implementationFactory;

        //
        // Summary:
        //     Gets the Microsoft.Extensions.DependencyInjection.ServiceLifetime of the service.
        public ServiceLifetime Lifetime { get; }

        //
        // Summary:
        //     Get the key of the service, if applicable.
        public object ServiceKey { get; }

        //
        // Summary:
        //     Gets the System.Type of the service.
        public Type ServiceType { get; }

        //
        // Summary:
        //     Gets the System.Type that implements the service.
        public Type ImplementationType
        {
            get
            {
                if (IsKeyedService)
                {
                    ThrowKeyedDescriptor();
                }

                return _implementationType;
            }
        }

        //
        // Summary:
        //     Gets the System.Type that implements the service.
        public Type KeyedImplementationType
        {
            get
            {
                if (!IsKeyedService)
                {
                    ThrowNonKeyedDescriptor();
                }

                return _implementationType;
            }
        }

        //
        // Summary:
        //     Gets the instance that implements the service.
        public object ImplementationInstance
        {
            get
            {
                if (IsKeyedService)
                {
                    ThrowKeyedDescriptor();
                }

                return _implementationInstance;
            }
        }

        //
        // Summary:
        //     Gets the instance that implements the service.
        public object KeyedImplementationInstance
        {
            get
            {
                if (!IsKeyedService)
                {
                    ThrowNonKeyedDescriptor();
                }

                return _implementationInstance;
            }
        }

        //
        // Summary:
        //     Gets the factory used for creating service instances.
        public Func<IServiceProvider, object> ImplementationFactory
        {
            get
            {
                if (IsKeyedService)
                {
                    ThrowKeyedDescriptor();
                }

                return (Func<IServiceProvider, object>)_implementationFactory;
            }
        }

        //
        // Summary:
        //     Gets the factory used for creating Keyed service instances.
        public Func<IServiceProvider, object, object> KeyedImplementationFactory
        {
            get
            {
                if (!IsKeyedService)
                {
                    ThrowNonKeyedDescriptor();
                }

                return (Func<IServiceProvider, object, object>)_implementationFactory;
            }
        }

        //
        // Summary:
        //     Indicates whether the service is a keyed service.
        public bool IsKeyedService => ServiceKey != null;

        //
        // Summary:
        //     Initializes a new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified implementationType.
        //
        // Parameters:
        //   serviceType:
        //     The System.Type of the service.
        //
        //   implementationType:
        //     The System.Type implementing the service.
        //
        //   lifetime:
        //     The Microsoft.Extensions.DependencyInjection.ServiceLifetime of the service.
        public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifetime lifetime)
            : this(serviceType, null, implementationType, lifetime)
        {
        }

        //
        // Summary:
        //     Initializes a new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified implementationType.
        //
        // Parameters:
        //   serviceType:
        //     The System.Type of the service.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationType:
        //     The System.Type implementing the service.
        //
        //   lifetime:
        //     The Microsoft.Extensions.DependencyInjection.ServiceLifetime of the service.
        public ServiceDescriptor(Type serviceType, object serviceKey, Type implementationType, ServiceLifetime lifetime)
            : this(serviceType, serviceKey, lifetime)
        {
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(implementationType, "implementationType");
            _implementationType = implementationType;
        }

        //
        // Summary:
        //     Initializes a new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified instance as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton.
        //
        //
        // Parameters:
        //   serviceType:
        //     The System.Type of the service.
        //
        //   instance:
        //     The instance implementing the service.
        public ServiceDescriptor(Type serviceType, object instance)
            : this(serviceType, null, instance)
        {
        }

        //
        // Summary:
        //     Initializes a new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified instance as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton.
        //
        //
        // Parameters:
        //   serviceType:
        //     The System.Type of the service.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   instance:
        //     The instance implementing the service.
        public ServiceDescriptor(Type serviceType, object serviceKey, object instance)
            : this(serviceType, serviceKey, ServiceLifetime.Singleton)
        {
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(instance, "instance");
            _implementationInstance = instance;
        }

        //
        // Summary:
        //     Initializes a new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified factory.
        //
        // Parameters:
        //   serviceType:
        //     The System.Type of the service.
        //
        //   factory:
        //     A factory used for creating service instances.
        //
        //   lifetime:
        //     The Microsoft.Extensions.DependencyInjection.ServiceLifetime of the service.
        public ServiceDescriptor(Type serviceType, Func<IServiceProvider, object> factory, ServiceLifetime lifetime)
            : this(serviceType, (object)null, lifetime)
        {
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(factory, "factory");
            _implementationFactory = factory;
        }

        //
        // Summary:
        //     Initializes a new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified factory.
        //
        // Parameters:
        //   serviceType:
        //     The System.Type of the service.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   factory:
        //     A factory used for creating service instances.
        //
        //   lifetime:
        //     The Microsoft.Extensions.DependencyInjection.ServiceLifetime of the service.
        public ServiceDescriptor(Type serviceType, object serviceKey, Func<IServiceProvider, object, object> factory, ServiceLifetime lifetime)
            : this(serviceType, serviceKey, lifetime)
        {
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(factory, "factory");
            if (serviceKey == null)
            {
                Func<IServiceProvider, object> implementationFactory = (sp) => factory(sp, null);
                _implementationFactory = implementationFactory;
            }
            else
            {
                _implementationFactory = factory;
            }
        }

        private ServiceDescriptor(Type serviceType, object serviceKey, ServiceLifetime lifetime)
        {
            Lifetime = lifetime;
            ServiceType = serviceType;
            ServiceKey = serviceKey;
        }

        public override string ToString()
        {
            string text = $"{"ServiceType"}: {ServiceType} {"Lifetime"}: {Lifetime} ";
            if (IsKeyedService)
            {
                text += $"{"ServiceKey"}: {ServiceKey} ";
                if (KeyedImplementationType != null)
                {
                    return text + $"{"KeyedImplementationType"}: {KeyedImplementationType}";
                }

                if (KeyedImplementationFactory != null)
                {
                    return text + $"{"KeyedImplementationFactory"}: {KeyedImplementationFactory/*.Method*/}";
                }

                return text + $"{"KeyedImplementationInstance"}: {KeyedImplementationInstance}";
            }

            if (ImplementationType != null)
            {
                return text + $"{"ImplementationType"}: {ImplementationType}";
            }

            if (ImplementationFactory != null)
            {
                return text + $"{"ImplementationFactory"}: {ImplementationFactory/*.Method*/}";
            }

            return text + $"{"ImplementationInstance"}: {ImplementationInstance}";
        }

        internal Type GetImplementationType()
        {
            if (ServiceKey == null)
            {
                if (ImplementationType != null)
                {
                    return ImplementationType;
                }

                if (ImplementationInstance != null)
                {
                    return ImplementationInstance.GetType();
                }

                if (ImplementationFactory != null)
                {
                    Type[] genericTypeArguments = ImplementationFactory.GetType().GetGenericArguments();//.GenericTypeArguments;
                    return genericTypeArguments[1];
                }
            }
            else
            {
                if (KeyedImplementationType != null)
                {
                    return KeyedImplementationType;
                }

                if (KeyedImplementationInstance != null)
                {
                    return KeyedImplementationInstance.GetType();
                }

                if (KeyedImplementationFactory != null)
                {
                    Type[] genericTypeArguments2 = KeyedImplementationFactory.GetType().GetGenericArguments();//.GenericTypeArguments;
                    return genericTypeArguments2[2];
                }
            }

            return null;
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified TService, TImplementation, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
        //     lifetime.
        //
        // Type parameters:
        //   TService:
        //     The type of the service.
        //
        //   TImplementation:
        //     The type of the implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor Transient<TService, TImplementation>() where TService : class where TImplementation : class, TService
        {
            return DescribeKeyed<TService, TImplementation>(null, ServiceLifetime.Transient);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified TService, TImplementation, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
        //     lifetime.
        //
        // Parameters:
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service.
        //
        //   TImplementation:
        //     The type of the implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor KeyedTransient<TService, TImplementation>(object serviceKey) where TService : class where TImplementation : class, TService
        {
            return DescribeKeyed<TService, TImplementation>(serviceKey, ServiceLifetime.Transient);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified service and implementationType and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
        //     lifetime.
        //
        // Parameters:
        //   service:
        //     The type of the service.
        //
        //   implementationType:
        //     The type of the implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor Transient(Type service, Type implementationType)
        {
            ThrowHelperExtension.ThrowIfNull(service, "service");
            ThrowHelperExtension.ThrowIfNull(implementationType, "implementationType");
            return Describe(service, implementationType, ServiceLifetime.Transient);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified service and implementationType and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
        //     lifetime.
        //
        // Parameters:
        //   service:
        //     The type of the service.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationType:
        //     The type of the implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor KeyedTransient(Type service, object serviceKey, Type implementationType)
        {
            ThrowHelperExtension.ThrowIfNull(service, "service");
            ThrowHelperExtension.ThrowIfNull(implementationType, "implementationType");
            return DescribeKeyed(service, serviceKey, implementationType, ServiceLifetime.Transient);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified TService, TImplementation, implementationFactory, and the
        //     Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient lifetime.
        //
        //
        // Parameters:
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        // Type parameters:
        //   TService:
        //     The type of the service.
        //
        //   TImplementation:
        //     The type of the implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor Transient<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        {
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return Describe(typeof(TService), (sp) => implementationFactory(sp), ServiceLifetime.Transient);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified TService, TImplementation, implementationFactory, and the
        //     Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient lifetime.
        //
        //
        // Parameters:
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        // Type parameters:
        //   TService:
        //     The type of the service.
        //
        //   TImplementation:
        //     The type of the implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor KeyedTransient<TService, TImplementation>(object serviceKey, Func<IServiceProvider, object, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        {
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return DescribeKeyed(typeof(TService), serviceKey, (sp, key) => implementationFactory(sp, key), ServiceLifetime.Transient);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified TService, implementationFactory, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
        //     lifetime.
        //
        // Parameters:
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        // Type parameters:
        //   TService:
        //     The type of the service.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor Transient<TService>(Func<IServiceProvider, TService> implementationFactory) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return Describe(typeof(TService), (sp) => implementationFactory(sp), ServiceLifetime.Transient);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified TService, implementationFactory, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
        //     lifetime.
        //
        // Parameters:
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        // Type parameters:
        //   TService:
        //     The type of the service.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor KeyedTransient<TService>(object serviceKey, Func<IServiceProvider, object, TService> implementationFactory) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return DescribeKeyed(typeof(TService), serviceKey, (sp, key) => implementationFactory(sp, key), ServiceLifetime.Transient);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified service, implementationFactory, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
        //     lifetime.
        //
        // Parameters:
        //   service:
        //     The type of the service.
        //
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor Transient(Type service, Func<IServiceProvider, object> implementationFactory)
        {
            ThrowHelperExtension.ThrowIfNull(service, "service");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return Describe(service, implementationFactory, ServiceLifetime.Transient);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified service, implementationFactory, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
        //     lifetime.
        //
        // Parameters:
        //   service:
        //     The type of the service.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor KeyedTransient(Type service, object serviceKey, Func<IServiceProvider, object, object> implementationFactory)
        {
            ThrowHelperExtension.ThrowIfNull(service, "service");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return DescribeKeyed(service, serviceKey, implementationFactory, ServiceLifetime.Transient);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified TService, TImplementation, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
        //     lifetime.
        //
        // Type parameters:
        //   TService:
        //     The type of the service.
        //
        //   TImplementation:
        //     The type of the implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor Scoped<TService, TImplementation>() where TService : class where TImplementation : class, TService
        {
            return DescribeKeyed<TService, TImplementation>(null, ServiceLifetime.Scoped);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified TService, TImplementation, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
        //     lifetime.
        //
        // Parameters:
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service.
        //
        //   TImplementation:
        //     The type of the implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor KeyedScoped<TService, TImplementation>(object serviceKey) where TService : class where TImplementation : class, TService
        {
            return DescribeKeyed<TService, TImplementation>(serviceKey, ServiceLifetime.Scoped);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified service and implementationType and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
        //     lifetime.
        //
        // Parameters:
        //   service:
        //     The type of the service.
        //
        //   implementationType:
        //     The type of the implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor Scoped(Type service, Type implementationType)
        {
            return Describe(service, implementationType, ServiceLifetime.Scoped);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified service and implementationType and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
        //     lifetime.
        //
        // Parameters:
        //   service:
        //     The type of the service.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationType:
        //     The type of the implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor KeyedScoped(Type service, object serviceKey, Type implementationType)
        {
            return DescribeKeyed(service, serviceKey, implementationType, ServiceLifetime.Scoped);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified TService, TImplementation, implementationFactory, and the
        //     Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped lifetime.
        //
        // Parameters:
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        // Type parameters:
        //   TService:
        //     The type of the service.
        //
        //   TImplementation:
        //     The type of the implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor Scoped<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        {
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return Describe(typeof(TService), (sp) => implementationFactory(sp), ServiceLifetime.Scoped);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified TService, TImplementation, implementationFactory, and the
        //     Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped lifetime.
        //
        // Parameters:
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        // Type parameters:
        //   TService:
        //     The type of the service.
        //
        //   TImplementation:
        //     The type of the implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor KeyedScoped<TService, TImplementation>(object serviceKey, Func<IServiceProvider, object, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        {
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return DescribeKeyed(typeof(TService), serviceKey, (sp, key) => implementationFactory(sp, key), ServiceLifetime.Scoped);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified TService, implementationFactory, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
        //     lifetime.
        //
        // Parameters:
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        // Type parameters:
        //   TService:
        //     The type of the service.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor Scoped<TService>(Func<IServiceProvider, TService> implementationFactory) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return Describe(typeof(TService), (sp) => implementationFactory(sp), ServiceLifetime.Scoped);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified TService, implementationFactory, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
        //     lifetime.
        //
        // Parameters:
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        // Type parameters:
        //   TService:
        //     The type of the service.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor KeyedScoped<TService>(object serviceKey, Func<IServiceProvider, object, TService> implementationFactory) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return DescribeKeyed(typeof(TService), serviceKey, (sp, key) => implementationFactory(sp, key), ServiceLifetime.Scoped);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified service, implementationFactory, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
        //     lifetime.
        //
        // Parameters:
        //   service:
        //     The type of the service.
        //
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor Scoped(Type service, Func<IServiceProvider, object> implementationFactory)
        {
            ThrowHelperExtension.ThrowIfNull(service, "service");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return Describe(service, implementationFactory, ServiceLifetime.Scoped);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified service, implementationFactory, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
        //     lifetime.
        //
        // Parameters:
        //   service:
        //     The type of the service.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor KeyedScoped(Type service, object serviceKey, Func<IServiceProvider, object, object> implementationFactory)
        {
            ThrowHelperExtension.ThrowIfNull(service, "service");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return DescribeKeyed(service, serviceKey, implementationFactory, ServiceLifetime.Scoped);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified TService, TImplementation, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     lifetime.
        //
        // Type parameters:
        //   TService:
        //     The type of the service.
        //
        //   TImplementation:
        //     The type of the implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor Singleton<TService, TImplementation>() where TService : class where TImplementation : class, TService
        {
            return DescribeKeyed<TService, TImplementation>(null, ServiceLifetime.Singleton);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified TService, TImplementation, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     lifetime.
        //
        // Parameters:
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        // Type parameters:
        //   TService:
        //     The type of the service.
        //
        //   TImplementation:
        //     The type of the implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor KeyedSingleton<TService, TImplementation>(object serviceKey) where TService : class where TImplementation : class, TService
        {
            return DescribeKeyed<TService, TImplementation>(serviceKey, ServiceLifetime.Singleton);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified service and implementationType and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     lifetime.
        //
        // Parameters:
        //   service:
        //     The type of the service.
        //
        //   implementationType:
        //     The type of the implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor Singleton(Type service, Type implementationType)
        {
            ThrowHelperExtension.ThrowIfNull(service, "service");
            ThrowHelperExtension.ThrowIfNull(implementationType, "implementationType");
            return Describe(service, implementationType, ServiceLifetime.Singleton);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified service and implementationType and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     lifetime.
        //
        // Parameters:
        //   service:
        //     The type of the service.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationType:
        //     The type of the implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor KeyedSingleton(Type service, object serviceKey, Type implementationType)
        {
            ThrowHelperExtension.ThrowIfNull(service, "service");
            ThrowHelperExtension.ThrowIfNull(implementationType, "implementationType");
            return DescribeKeyed(service, serviceKey, implementationType, ServiceLifetime.Singleton);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified TService, TImplementation, implementationFactory, and the
        //     Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton lifetime.
        //
        //
        // Parameters:
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        // Type parameters:
        //   TService:
        //     The type of the service.
        //
        //   TImplementation:
        //     The type of the implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor Singleton<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        {
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return Describe(typeof(TService), (sp) => implementationFactory(sp), ServiceLifetime.Singleton);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified TService, TImplementation, implementationFactory, and the
        //     Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton lifetime.
        //
        //
        // Parameters:
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        // Type parameters:
        //   TService:
        //     The type of the service.
        //
        //   TImplementation:
        //     The type of the implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor KeyedSingleton<TService, TImplementation>(object serviceKey, Func<IServiceProvider, object, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        {
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return DescribeKeyed(typeof(TService), serviceKey, (sp, key) => implementationFactory(sp, key), ServiceLifetime.Singleton);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified TService, implementationFactory, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     lifetime.
        //
        // Parameters:
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        // Type parameters:
        //   TService:
        //     The type of the service.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor Singleton<TService>(Func<IServiceProvider, TService> implementationFactory) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return Describe(typeof(TService), (sp) => implementationFactory(sp), ServiceLifetime.Singleton);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified TService, implementationFactory, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     lifetime.
        //
        // Parameters:
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        // Type parameters:
        //   TService:
        //     The type of the service.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor KeyedSingleton<TService>(object serviceKey, Func<IServiceProvider, object, TService> implementationFactory) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return DescribeKeyed(typeof(TService), serviceKey, (sp, key) => implementationFactory(sp, key), ServiceLifetime.Singleton);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified serviceType, implementationFactory, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     lifetime.
        //
        // Parameters:
        //   serviceType:
        //     The type of the service.
        //
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor Singleton(Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return Describe(serviceType, implementationFactory, ServiceLifetime.Singleton);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified serviceType, implementationFactory, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     lifetime.
        //
        // Parameters:
        //   serviceType:
        //     The type of the service.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor KeyedSingleton(Type serviceType, object serviceKey, Func<IServiceProvider, object, object> implementationFactory)
        {
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(implementationFactory, "implementationFactory");
            return DescribeKeyed(serviceType, serviceKey, implementationFactory, ServiceLifetime.Singleton);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified TService, implementationInstance, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     lifetime.
        //
        // Parameters:
        //   implementationInstance:
        //     The instance of the implementation.
        //
        // Type parameters:
        //   TService:
        //     The type of the service.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor Singleton<TService>(TService implementationInstance) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(implementationInstance, "implementationInstance");
            return Singleton(typeof(TService), implementationInstance);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified TService, implementationInstance, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     lifetime.
        //
        // Parameters:
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationInstance:
        //     The instance of the implementation.
        //
        // Type parameters:
        //   TService:
        //     The type of the service.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor KeyedSingleton<TService>(object serviceKey, TService implementationInstance) where TService : class
        {
            ThrowHelperExtension.ThrowIfNull(implementationInstance, "implementationInstance");
            return KeyedSingleton(typeof(TService), serviceKey, implementationInstance);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified serviceType, implementationInstance, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     lifetime.
        //
        // Parameters:
        //   serviceType:
        //     The type of the service.
        //
        //   implementationInstance:
        //     The instance of the implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor Singleton(Type serviceType, object implementationInstance)
        {
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(implementationInstance, "implementationInstance");
            return new ServiceDescriptor(serviceType, implementationInstance);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified serviceType, implementationInstance, and the Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     lifetime.
        //
        // Parameters:
        //   serviceType:
        //     The type of the service.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationInstance:
        //     The instance of the implementation.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor KeyedSingleton(Type serviceType, object serviceKey, object implementationInstance)
        {
            ThrowHelperExtension.ThrowIfNull(serviceType, "serviceType");
            ThrowHelperExtension.ThrowIfNull(implementationInstance, "implementationInstance");
            return new ServiceDescriptor(serviceType, serviceKey, implementationInstance);
        }

        private static ServiceDescriptor DescribeKeyed<TService, TImplementation>(object serviceKey, ServiceLifetime lifetime) where TService : class where TImplementation : class, TService
        {
            return DescribeKeyed(typeof(TService), serviceKey, typeof(TImplementation), lifetime);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified serviceType, implementationType, and lifetime.
        //
        // Parameters:
        //   serviceType:
        //     The type of the service.
        //
        //   implementationType:
        //     The type of the implementation.
        //
        //   lifetime:
        //     The lifetime of the service.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor Describe(Type serviceType, Type implementationType, ServiceLifetime lifetime)
        {
            return new ServiceDescriptor(serviceType, implementationType, lifetime);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified serviceType, implementationType, and lifetime.
        //
        // Parameters:
        //   serviceType:
        //     The type of the service.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationType:
        //     The type of the implementation.
        //
        //   lifetime:
        //     The lifetime of the service.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor DescribeKeyed(Type serviceType, object serviceKey, Type implementationType, ServiceLifetime lifetime)
        {
            return new ServiceDescriptor(serviceType, serviceKey, implementationType, lifetime);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified serviceType, implementationFactory, and lifetime.
        //
        // Parameters:
        //   serviceType:
        //     The type of the service.
        //
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        //   lifetime:
        //     The lifetime of the service.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor Describe(Type serviceType, Func<IServiceProvider, object> implementationFactory, ServiceLifetime lifetime)
        {
            return new ServiceDescriptor(serviceType, implementationFactory, lifetime);
        }

        //
        // Summary:
        //     Creates an instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     with the specified serviceType, implementationFactory, and lifetime.
        //
        // Parameters:
        //   serviceType:
        //     The type of the service.
        //
        //   serviceKey:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey of
        //     the service.
        //
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        //   lifetime:
        //     The lifetime of the service.
        //
        // Returns:
        //     A new instance of Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        public static ServiceDescriptor DescribeKeyed(Type serviceType, object serviceKey, Func<IServiceProvider, object, object> implementationFactory, ServiceLifetime lifetime)
        {
            return new ServiceDescriptor(serviceType, serviceKey, implementationFactory, lifetime);
        }

        //private string DebuggerToString()
        //{
        //    string text = $"Lifetime = {Lifetime}, ServiceType = \"{ServiceType.FullName}\"";
        //    if (IsKeyedService)
        //    {
        //        text += $", ServiceKey = \"{ServiceKey}\"";
        //        if (KeyedImplementationType != null)
        //        {
        //            return text + ", KeyedImplementationType = \"" + KeyedImplementationType.FullName + "\"";
        //        }

        //        if (KeyedImplementationFactory != null)
        //        {
        //            return text + $", KeyedImplementationFactory = {KeyedImplementationFactory/*.Method*/}";
        //        }

        //        return text + $", KeyedImplementationInstance = {KeyedImplementationInstance}";
        //    }

        //    if (ImplementationType != null)
        //    {
        //        return text + ", ImplementationType = \"" + ImplementationType.FullName + "\"";
        //    }

        //    if (ImplementationFactory != null)
        //    {
        //        return text + $", ImplementationFactory = {ImplementationFactory/*.Method*/}";
        //    }

        //    return text + $", ImplementationInstance = {ImplementationInstance}";
        //}

        private static void ThrowKeyedDescriptor()
        {
            throw new InvalidOperationException("Key descriptor misuse");
        }

        private static void ThrowNonKeyedDescriptor()
        {
            throw new InvalidOperationException("Non key descriptor misuse");
        }
    }
}
