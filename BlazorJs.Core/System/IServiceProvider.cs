namespace System
{
    //    public partial interface IServiceProvider
    //    {
    //        object GetService(Type type);
    //        object GetKeyedService(Type type, object key);
    //    }


    [H5.Convention(Member = H5.ConventionMember.Field | H5.ConventionMember.Method, Notation = H5.Notation.CamelCase)]
    public interface IServiceScope
    {
        IServiceProvider Service { get; }
    }

    public static class ServiceProviderExtensions
    {
        class ServiceScope : IServiceScope
        {
            public IServiceProvider Service { get; private set; }
            public ServiceScope(IServiceProvider serviceProvider)
            {
                Service = serviceProvider;
            }
        }

        public static IServiceScope CreateScope(this IServiceProvider serviceProvider)
        {
            return new ServiceScope(serviceProvider);
        }
    }
}
