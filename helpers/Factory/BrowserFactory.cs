namespace SauceLabsAutomation.Factory;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

class BrowserFactory
{
    private static IWebDriver? webDriver;

    public static IWebDriver WebDriver
    {
        get
        {
            if (webDriver == null) Init();
            return webDriver ?? throw new NullReferenceException("Browser driver was not initialized.");
        }
        set => webDriver = value;
    }

    public static void Init(string browser = "Chrome")
    {
        switch (browser)
        {
            case "Firefox":
                FirefoxOptions firefoxOptions = new();
                firefoxOptions.AddArguments("--incognito", "--start-maximized");
                webDriver = new FirefoxDriver(firefoxOptions);
                break;

            case "Chrome":
                ChromeOptions chromeOptions = new();
                chromeOptions.AddArguments("--incognito", "--start-maximized");
                webDriver = new ChromeDriver(chromeOptions);
                break;

            case "Edge":
                EdgeOptions edgeOptions = new();
                edgeOptions.AddArguments("--incognito", "--start-maximized");
                webDriver = new EdgeDriver(edgeOptions);
                break;
        }
    }

    public static void CloseBrowser()
    {
        webDriver?.Close();
        webDriver?.Quit();
    }
}