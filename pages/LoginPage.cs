using OpenQA.Selenium;

namespace SauceLabsAutomation
{
    internal class LoginPage(IWebDriver driver) : BasePage(driver)
    {
        readonly By logo = By.ClassName("login_logo");
        readonly By userName = By.Id("user-name");
        readonly By password = By.Id("password");
        readonly By loginButton = By.Id("login-button");

        public override void VerifyPage()
        {
            Assert.AreEqual(SITE_URL, webDriver.Url);
            Assert.AreEqual("Swag Labs", webDriver.Title);
            Assert.IsTrue(GetElement(logo).Displayed);
            Assert.IsTrue(GetElement(userName).Displayed);
            Assert.IsTrue(GetElement(password).Displayed);
            Assert.IsTrue(GetElement(loginButton).Displayed);
        }

        public void Login()
        {
            GetElement(userName).SendKeys("standard_user");
            GetElement(password).SendKeys("secret_sauce");
            GetElement(loginButton).Click();
        }
    }
}
