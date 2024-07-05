using OpenQA.Selenium;

namespace SauceLabsAutomation
{
    internal class OrderCompletionPage : BasePage
    {

        public OrderCompletionPage(IWebDriver driver) : base(driver)
        {
            this.SITE_URL += "checkout-complete.html";
        }

        readonly By title = By.ClassName("title");
        readonly By checkoutHeader = By.ClassName("complete-header");
        readonly By checkoutText = By.ClassName("complete-text");
        readonly By closeButton = By.Id("back-to-products");

        public void Close()
        {
            GetElement(closeButton).Click();
        }

        public override void VerifyPage()
        {
            Assert.AreEqual(SITE_URL, webDriver.Url);
            Assert.AreEqual("Swag Labs", webDriver.Title);
            Assert.IsTrue(GetElement(title).Displayed);
            Assert.AreEqual(GetElement(title).Text, "Checkout: Complete!");

            Assert.IsTrue(GetElement(checkoutHeader).Displayed);
            Assert.AreEqual(GetElement(checkoutHeader).Text, "Thank you for your order!");

            Assert.IsTrue(GetElement(checkoutText).Displayed);
            Assert.IsTrue(GetElement(checkoutText).Text.Contains("Your order has been dispatched"));

            Assert.IsTrue(GetElement(closeButton).Displayed);
            Assert.AreEqual(GetElement(closeButton).Text, "Back Home");
        }
    }
}