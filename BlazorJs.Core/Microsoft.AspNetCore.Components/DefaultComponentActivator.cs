using System;

namespace Microsoft.AspNetCore.Components
{
    internal sealed class DefaultComponentActivator : IComponentActivator
    {
        private readonly IServiceProvider serviceProvider;

        public DefaultComponentActivator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public IComponent CreateInstance(Type componentType)
        {
            if (!typeof(IComponent).IsAssignableFrom(componentType))
            {
                throw new ArgumentException($"The type {componentType.FullName} does not implement {nameof(IComponent)}.", nameof(componentType));
            }

            return (IComponent)(serviceProvider.GetService(componentType) ?? Activator.CreateInstance(componentType));
        }
    }
}
