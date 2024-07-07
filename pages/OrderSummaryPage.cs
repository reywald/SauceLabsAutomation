using OpenQA.Selenium;

namespace SauceLabsAutomation
{
    internal class OrderSummaryPage : BasePage
    {

        public OrderSummaryPage(IWebDriver driver, Product product) : base(driver)
        {
            this.product = product;
            this.pageURL = base.pageURL + GetURL().Checkout2;
        }

        readonly Product product;

        readonly By title = By.ClassName("title");
        readonly By checkoutQty = By.ClassName("cart_quantity");
        readonly By checkoutName = By.ClassName("inventory_item_name");
        readonly By checkoutDescription = By.ClassName("inventory_item_desc");
        readonly By checkoutPrice = By.ClassName("inventory_item_price");
        readonly By checkoutPriceTotal = By.ClassName("summary_subtotal_label");
        readonly By checkoutTax = By.ClassName("summary_tax_label");
        readonly By checkoutTotal = By.ClassName("summary_total_label");
        readonly By finishButton = By.Id("finish");

        public void Finish()
        {
            GetElement(finishButton).Click();
        }

        public override void VerifyPage()
        {
            Assert.AreEqual(pageURL, webDriver.Url);
            Assert.AreEqual("Swag Labs", webDriver.Title);
            Assert.IsTrue(GetElement(title).Displayed);
            Assert.AreEqual(GetElement(title).Text, "Checkout: Overview");

            Assert.IsTrue(GetElement(checkoutQty).Displayed);
            Assert.AreEqual(GetElement(checkoutQty).Text, product.quantity);

            Assert.IsTrue(GetElement(checkoutName).Displayed);
            Assert.AreEqual(GetElement(checkoutName).Text, product.name);

            Assert.IsTrue(GetElement(checkoutDescription).Displayed);
            Assert.AreEqual(GetElement(checkoutDescription).Text, product.description);

            Assert.IsTrue(GetElement(checkoutPrice).Displayed);
            Assert.AreEqual(GetElement(checkoutPrice).Text, product.price);

            Assert.IsTrue(GetElement(checkoutPriceTotal).Displayed);
            Assert.IsTrue(GetElement(checkoutPriceTotal).Text.Contains(product.price));

            Assert.IsTrue(GetElement(checkoutTax).Displayed);

            Assert.IsTrue(GetElement(checkoutTotal).Displayed);
            VerifyCost();

            Assert.IsTrue(GetElement(finishButton).Displayed);
            Assert.AreEqual(GetElement(finishButton).Text, "Finish");
        }

        private void VerifyCost()
        {
            double itemPrice = Convert.ToDouble(GetElement(checkoutPrice).Text.Substring(1));
            double tax = Convert.ToDouble(GetElement(checkoutTax).Text.Substring(6));
            double total = Convert.ToDouble(GetElement(checkoutTotal).Text.Substring(8));
            Assert.IsTrue((itemPrice + tax) == total);
        }
    }
}