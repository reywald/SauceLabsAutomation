using System.Collections.ObjectModel;
using OpenQA.Selenium;
using SauceLabsAutomation.TestConfiguration;

namespace SauceLabsAutomation
{
    public abstract class BasePage(IWebDriver driver)
    {
        protected string pageURL = ConfigFactory.GetURLConfig().URL.BaseURL;

        protected static URL GetURL() => ConfigFactory.GetURLConfig().URL;

        protected readonly IWebDriver webDriver = driver;


        protected IWebElement GetElement(By element)
        {
            return webDriver.FindElement(element);
        }

        protected ReadOnlyCollection<IWebElement> GetElements(By elements)
        {
            return webDriver.FindElements(elements);
        }

        protected virtual void StoreProduct() { }

        public abstract void VerifyPage();

        public virtual void Visit()
        {
            webDriver.Url = pageURL;
        }
    }
}
