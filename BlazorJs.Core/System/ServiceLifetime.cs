namespace System
{
    //
    // Summary:
    //     Specifies the lifetime of a service in an Microsoft.Extensions.DependencyInjection.IServiceCollection.
    public enum ServiceLifetime
    {
        //
        // Summary:
        //     Specifies that a single instance of the service will be created.
        Singleton,
        //
        // Summary:
        //     Specifies that a new instance of the service will be created for each scope.
        //
        //
        // Remarks:
        //     In ASP.NET Core applications a scope is created around each server request.
        Scoped,
        //
        // Summary:
        //     Specifies that a new instance of the service will be created every time it is
        //     requested.
        Transient
    }
}
