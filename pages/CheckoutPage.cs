using OpenQA.Selenium;
using SauceLabsAutomation.TestConfiguration;

namespace SauceLabsAutomation
{
    internal class CheckoutPage : BasePage
    {

        public CheckoutPage(IWebDriver driver) : base(driver)
        {
            this.pageURL = base.pageURL + GetURL().Checkout1;
        }

        // readonly Product product;

        readonly By title = By.ClassName("title");
        readonly By firstName = By.Id("first-name");
        readonly By lastName = By.Id("last-name");
        readonly By postalCode = By.Id("postal-code");
        readonly By continueButton = By.Id("continue");
        readonly ShippingAddresses shippingAddresses = ConfigFactory.GetShippingConfig();

        public void Continue()
        {
            GetElement(continueButton).Click();
        }

        public void FillForm()
        {
            string fname = shippingAddresses.Shipping.FirstName;
            string lname = shippingAddresses.Shipping.LastName;
            string pcode = shippingAddresses.Shipping.PostalCode;

            GetElement(firstName).SendKeys(fname);
            GetElement(lastName).SendKeys(lname);
            GetElement(postalCode).SendKeys(pcode);
        }

        public override void VerifyPage()
        {
            Assert.AreEqual(pageURL, webDriver.Url);
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