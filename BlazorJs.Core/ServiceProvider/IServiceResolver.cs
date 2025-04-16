using System;

namespace BlazorJs.ServiceProvider
{
    public partial interface IServiceResolver
    {
        object TryResolve(IServiceProvider serviceProvier, Type serviceType, object serviceKey, bool all, ServiceLifetime currentScope);
    }
}
