using System.Configuration;

namespace SauceLabsAutomation.TestConfiguration;

public class Credential : ConfigurationElement
{

    [ConfigurationProperty(name: "name", IsKey = true, IsRequired = true)]
    public string Name
    {
        get => (string)this["name"];
        set => this["name"] = value;
    }

    [ConfigurationProperty(name: "username", IsRequired = true)]
    public string Username
    {
        get => (string)this["username"];
        set => this["username"] = value;
    }

    [ConfigurationProperty(name: "password", IsRequired = true)]
    public string Password
    {
        get => (string)this["password"];
        set => this["password"] = value;
    }

    [ConfigurationProperty(name: "cookie", IsRequired = true)]
    public string Cookie
    {
        get => (string)this["cookie"];
        set => this["cookie"] = value;
    }
}
