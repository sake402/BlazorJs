using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.Configuration
{
    public interface IConfiguration
    {
        //
        // Summary:
        //     Gets or sets a configuration value.
        //
        // Parameters:
        //   key:
        //     The configuration key.
        //
        // Returns:
        //     The configuration value.
        string? this[string key] { get; set; }

        //
        // Summary:
        //     Gets a configuration sub-section with the specified key.
        //
        // Parameters:
        //   key:
        //     The key of the configuration section.
        //
        // Returns:
        //     The Microsoft.Extensions.Configuration.IConfigurationSection.
        //
        // Remarks:
        //     This method will never return null. If no matching sub-section is found with
        //     the specified key, an empty Microsoft.Extensions.Configuration.IConfigurationSection
        //     will be returned.
        IConfigurationSection GetSection(string key);

        //
        // Summary:
        //     Gets the immediate descendant configuration sub-sections.
        //
        // Returns:
        //     The configuration sub-sections.
        IEnumerable<IConfigurationSection> GetChildren();

        //
        // Summary:
        //     Returns a Microsoft.Extensions.Primitives.IChangeToken that can be used to observe
        //     when this configuration is reloaded.
        //
        // Returns:
        //     A Microsoft.Extensions.Primitives.IChangeToken.
        //IChangeToken GetReloadToken();
    }
}
