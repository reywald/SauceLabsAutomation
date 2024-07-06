using System.Configuration;

namespace SauceLabsAutomation.TestConfiguration;

public class Security : ConfigurationSection
{
    [ConfigurationProperty("Credential")]
    public Credential Credential
    {
        get => (Credential)this["Credential"];
        set => value = (Credential)this["Credential"];
    }
}