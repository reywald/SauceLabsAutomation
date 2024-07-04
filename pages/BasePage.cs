using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using OpenQA.Selenium;

namespace SauceLabsAutomation
{
    public abstract class BasePage(IWebDriver driver)
    {
        protected string SITE_URL = "https://www.saucedemo.com/";
        protected readonly IWebDriver webDriver = driver;

        protected IWebElement GetElement(By element)
        {
            return this.webDriver.FindElement(element);
        }

        protected ReadOnlyCollection<IWebElement> GetElements(By elements)
        {
            return this.webDriver.FindElements(elements);
        }

        protected virtual void StoreProduct(ref Product product) { }

        public abstract void VerifyPage();

        public virtual void Visit()
        {
            this.webDriver.Url = this.SITE_URL;
        }
    }
}
