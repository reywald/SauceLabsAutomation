using System.Configuration;

namespace SauceLabsAutomation.TestConfiguration;

public sealed class ConfigFactory
{
    private ConfigFactory() { }

    public static Security GetSecurityConfig()
    {
        return (Security)ConfigurationManager.GetSection("Security");
    }

    public static URLS GetURLConfig()
    {
        return (URLS)ConfigurationManager.GetSection("URLs");
    }

    public static ShippingAddresses GetShippingConfig()
    {
        return (ShippingAddresses)ConfigurationManager.GetSection("ShippingAddresses");
    }
}
