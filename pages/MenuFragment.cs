using OpenQA.Selenium;

namespace SauceLabsAutomation
{
    internal class MenuFragment(IWebDriver driver)
    {

        readonly By menuButton = By.Id("react-burger-menu-btn");
        readonly By logout = By.Id("logout_sidebar_link");

        public void Logout()
        {
            driver.FindElement(menuButton).Click();
            Thread.Sleep(1000);
            driver.FindElement(logout).Click();
        }
    }
}