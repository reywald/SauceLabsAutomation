using System.Configuration;

namespace SauceLabsAutomation.TestConfiguration;

public class Shipping : ConfigurationElement
{

    [ConfigurationProperty(name: "name", IsKey = true, IsRequired = true)]
    public string Name
    {
        get => (string)this["name"];
        set => this["name"] = value;
    }

    [ConfigurationProperty(name: "firstName", IsRequired = true)]
    public string FirstName
    {
        get => (string)this["firstName"];
        set => this["firstName"] = value;
    }

    [ConfigurationProperty(name: "lastName", IsRequired = true)]
    public string LastName
    {
        get => (string)this["lastName"];
        set => this["lastName"] = value;
    }

    [ConfigurationProperty(name: "postalCode", IsRequired = true)]
    public string PostalCode
    {
        get => (string)this["postalCode"];
        set => this["postalCode"] = value;
    }
}
