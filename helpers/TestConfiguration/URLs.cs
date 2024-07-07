using System.Configuration;

namespace SauceLabsAutomation.TestConfiguration;

public class URLS : ConfigurationSection
{
    [ConfigurationProperty("URL")]
    public URL URL
    {
        get => (URL)this[nameof(URL)];
        set => value = (URL)this[nameof(URL)];
    }
}