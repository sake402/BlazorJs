using System.Collections.Generic;

namespace Microsoft.Extensions.Configuration
{
    public interface IConfigurationBuilder
    {
        IDictionary<string, object> Properties { get; }
        IList<IConfigurationSource> Sources { get; }

        IConfigurationBuilder Add(IConfigurationSource source);
        IConfigurationRoot Build();
    }
}
