using OpenQA.Selenium;

namespace SauceLabsAutomation
{
    internal class CartPage : BasePage
    {

        public CartPage(IWebDriver driver, Product product) : base(driver)
        {

            this.product = product;
            this.SITE_URL += "cart.html";
        }

        Product product;

        readonly By title = By.ClassName("title");
        readonly By cartQty = By.ClassName("cart_quantity");
        readonly By cartName = By.ClassName("inventory_item_name");
        readonly By cartDescription = By.ClassName("inventory_item_desc");
        readonly By cartPrice = By.ClassName("inventory_item_price");
        readonly By checkoutButton = By.Id("checkout");

        public void Checkout()
        {
            GetElement(checkoutButton).Click();
        }


        public override void VerifyPage()
        {
            Assert.AreEqual(SITE_URL, webDriver.Url);
            Assert.AreEqual("Swag Labs", webDriver.Title);
            Assert.IsTrue(GetElement(title).Displayed);
            Assert.AreEqual(GetElement(title).Text, "Your Cart");

            Assert.IsTrue(GetElement(cartQty).Displayed);
            Assert.AreEqual(GetElement(cartQty).Text, product.quantity);

            Assert.IsTrue(GetElement(cartName).Displayed);
            Assert.AreEqual(GetElement(cartName).Text, product.name);

            Assert.IsTrue(GetElement(cartDescription).Displayed);
            Assert.AreEqual(GetElement(cartDescription).Text, product.description);

            Assert.IsTrue(GetElement(cartPrice).Displayed);
            Assert.AreEqual(GetElement(cartPrice).Text, product.price);

            Assert.IsTrue(GetElement(checkoutButton).Displayed);
            Assert.AreEqual(GetElement(checkoutButton).Text, "Checkout");

        }
    }
}