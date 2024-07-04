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

        public abstract void VerifyPage();

        public void Visit()
        {
            this.webDriver.Url = this.SITE_URL;
        }
    }
}
