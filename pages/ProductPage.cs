using OpenQA.Selenium;

namespace SauceLabsAutomation
{
    internal class ProductPage : BasePage
    {

        public ProductPage(IWebDriver driver) : base(driver)
        {

            this.SITE_URL += "inventory-item.html?id=";
        }

        readonly By itemName = By.ClassName("inventory_details_name");
        readonly By itemDescription = By.ClassName("inventory_details_desc");
        readonly By itemPrice = By.ClassName("inventory_details_price");
        readonly By addToCart = By.ClassName("btn_inventory");
        readonly By cart = By.Id("shopping_cart_container");

        public void AddToCart()
        {
            GetElement(addToCart).Click();
            Assert.IsTrue(GetElement(cart).Text == "1");
            // Assert.IsTrue(addToCart.Text == "Remove");

        }

        public void OpenCart()
        {
            GetElement(cart).Click();
        }

        public override void VerifyPage()
        {
            Assert.IsTrue(this.webDriver.Url.Contains("1"));
            Assert.AreEqual("Swag Labs", webDriver.Title);

            Assert.IsTrue(GetElement(itemName).Displayed);
            Assert.AreEqual(GetElement(itemName).Text, "");

            Assert.IsTrue(GetElement(itemDescription).Displayed);
            Assert.AreEqual(GetElement(itemDescription).Text, "");

            Assert.IsTrue(GetElement(itemPrice).Displayed);
            Assert.AreEqual(GetElement(itemPrice).Text, "");

            Assert.IsTrue(GetElement(addToCart).Displayed);
            Assert.AreEqual(GetElement(addToCart).Text, "Add to cart");

            Assert.IsTrue(GetElement(cart).Displayed);
            Assert.IsTrue(GetElement(cart).Text.Length == 0);
        }
    }
}