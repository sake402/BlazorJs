using System;
using System.IO;

namespace Microsoft.Extensions.Configuration
{
    public static class ConfigurationExtension
    {
        public static void AddJsonStream(this IConfigurationBuilder configuration, Stream stream)
        {
            throw new NotImplementedException();
        }

        public static bool Exists(this IConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public static T Get<T>(this IConfiguration configuration)
        {
            throw new NotImplementedException();
        }
    }
}
