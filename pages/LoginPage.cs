using OpenQA.Selenium;
using SauceLabsAutomation.TestConfiguration;

namespace SauceLabsAutomation
{
    internal class LoginPage(IWebDriver driver) : BasePage(driver)
    {
        readonly By logo = By.ClassName("login_logo");
        readonly By userName = By.Id("user-name");
        readonly By password = By.Id("password");
        readonly By loginButton = By.Id("login-button");
        readonly Security security = ConfigFactory.GetSecurityConfig();

        public void Login()
        {
            string user = security.Credential.Username;
            string pass = security.Credential.Password;

            GetElement(userName).SendKeys(user);
            GetElement(password).SendKeys(pass);
            GetElement(loginButton).Click();
        }

        public void CheckLoggedIn()
        {
            string username = security.Credential.Username;
            string cookieUser = security.Credential.Cookie;

            Cookie sessionCookie = webDriver.Manage().Cookies.GetCookieNamed(cookieUser);
            Assert.AreEqual(sessionCookie.Value, username);
        }

        public override void VerifyPage()
        {
            Assert.AreEqual(pageURL, webDriver.Url);
            Assert.AreEqual("Swag Labs", webDriver.Title);
            Assert.IsTrue(GetElement(logo).Displayed);
            Assert.IsTrue(GetElement(userName).Displayed);
            Assert.IsTrue(GetElement(password).Displayed);
            Assert.IsTrue(GetElement(loginButton).Displayed);
        }
    }
}
