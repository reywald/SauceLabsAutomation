using System.Configuration;

namespace SauceLabsAutomation.TestConfiguration;

public sealed class ConfigFactory
{
    private ConfigFactory() { }

    public static Security GetSecurityConfig()
    {
        return (Security)ConfigurationManager.GetSection("Security");
    }

    public static URLConfig GetURLConfig()
    {
        return (URLConfig)ConfigurationManager.GetSection("URLs");
    }

    public static ShippingConfig GetShippingConfig()
    {
        return (ShippingConfig)ConfigurationManager.GetSection("ShippingInfo");
    }
}
