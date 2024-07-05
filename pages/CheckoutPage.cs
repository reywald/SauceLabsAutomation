using OpenQA.Selenium;

namespace SauceLabsAutomation
{
    internal class CheckoutPage : BasePage
    {

        public CheckoutPage(IWebDriver driver) : base(driver)
        {
            this.SITE_URL += "checkout-step-one.html";
        }

        // Product product;

        readonly By title = By.ClassName("title");
        readonly By firstName = By.Id("first-name");
        readonly By lastName = By.Id("last-name");
        readonly By postalCode = By.Id("postal-code");
        readonly By continueButton = By.Id("continue");

        public void Continue()
        {
            GetElement(continueButton).Click();
        }

        public void fillForm(string fname, string lname, string pcode)
        {
            GetElement(firstName).SendKeys(fname);
            GetElement(lastName).SendKeys(lname);
            GetElement(postalCode).SendKeys(pcode);
        }

        public override void VerifyPage()
        {
            Assert.AreEqual(SITE_URL, webDriver.Url);
            Assert.AreEqual("Swag Labs", webDriver.Title);
            Assert.IsTrue(GetElement(title).Displayed);
            Assert.AreEqual(GetElement(title).Text, "Checkout: Your Information");

            Assert.IsTrue(GetElement(firstName).Displayed);
            Assert.IsTrue(GetElement(lastName).Displayed);
            Assert.IsTrue(GetElement(postalCode).Displayed);
            Assert.IsTrue(GetElement(continueButton).Displayed);
            Assert.AreEqual(GetElement(continueButton).GetAttribute("value"), "Continue");
        }
    }
}