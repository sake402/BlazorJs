using System;

namespace Microsoft.AspNetCore.Components
{
    /// <summary>
    /// Represents an activator that can be used to instantiate components.
    /// The activator is not responsible for dependency injection, since the framework
    /// performs dependency injection to the resulting instances separately.
    /// </summary>
    public interface IComponentActivator
    {
        /// <summary>
        /// Creates a component of the specified type.
        /// </summary>
        /// <param name="componentType">The type of component to create.</param>
        /// <returns>A reference to the newly created component.</returns>
        IComponent CreateInstance(Type componentType);
    }
}
