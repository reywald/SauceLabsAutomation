using System.Configuration;

namespace SauceLabsAutomation.TestConfiguration;

public class ShippingAddresses : ConfigurationSection
{
    [ConfigurationProperty("ShippingAddress")]
    public Shipping Shipping
    {
        get => (Shipping)this["ShippingAddress"];
        set => value = (Shipping)this["ShippingAddress"];
    }
}