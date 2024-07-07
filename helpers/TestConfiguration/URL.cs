using System.Configuration;

namespace SauceLabsAutomation.TestConfiguration;

public class URL : ConfigurationElement
{
    [ConfigurationProperty(name: "name", IsKey = true, IsRequired = true)]
    public string Name
    {
        get => (string)this["name"];
        set => this["name"] = value;
    }

    [ConfigurationProperty(name: "baseURL", IsRequired = true)]
    public string BaseURL
    {
        get => (string)this["baseURL"];
        set => this["baseURL"] = value;
    }

    [ConfigurationProperty(name: "products", IsRequired = true)]
    public string Products
    {
        get => (string)this["products"];
        set => this["products"] = value;
    }

    [ConfigurationProperty(name: "product", IsRequired = true)]
    public string Product
    {
        get => (string)this["product"];
        set => this["product"] = value;
    }

    [ConfigurationProperty(name: "cart", IsRequired = true)]
    public string Cart
    {
        get => (string)this["cart"];
        set => this["cart"] = value;
    }

    [ConfigurationProperty(name: "checkout1", IsRequired = true)]
    public string Checkout1
    {
        get => (string)this["checkout1"];
        set => this["checkout1"] = value;
    }

    [ConfigurationProperty(name: "checkout2", IsRequired = true)]
    public string Checkout2
    {
        get => (string)this["checkout2"];
        set => this["checkout2"] = value;
    }

    [ConfigurationProperty(name: "checkoutFinal", IsRequired = true)]
    public string CheckoutFinal
    {
        get => (string)this["checkoutFinal"];
        set => this["checkoutFinal"] = value;
    }
}
