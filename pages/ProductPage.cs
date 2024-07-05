using OpenQA.Selenium;

namespace SauceLabsAutomation
{
    internal class ProductPage : BasePage
    {

        public ProductPage(IWebDriver driver, Product product) : base(driver)
        {
            this.product = product;
            this.SITE_URL += $"inventory-item.html?id={product.id}";
        }

        Product product;

        readonly By itemName = By.ClassName("inventory_details_name");
        readonly By itemDescription = By.ClassName("inventory_details_desc");
        readonly By itemPrice = By.ClassName("inventory_details_price");
        readonly By addToCart = By.ClassName("btn_inventory");
        readonly By cart = By.Id("shopping_cart_container");

        public void AddToCart()
        {
            GetElement(addToCart).Click();
            Assert.IsTrue(GetElement(cart).Text == "1");
            Assert.IsTrue(GetElement(addToCart).Text == "Remove");
            StoreProduct();
        }

        public void OpenCart()
        {
            GetElement(cart).Click();
        }

        protected override void StoreProduct()
        {
            product.description = GetElement(itemDescription).Text;
            product.price = GetElement(itemPrice).Text;
            product.quantity = GetElement(cart).Text;
        }


        public override void VerifyPage()
        {
            Assert.IsTrue(this.webDriver.Url.Contains($"{product.id}"));
            Assert.AreEqual("Swag Labs", webDriver.Title);

            Assert.IsTrue(GetElement(itemName).Displayed);
            Assert.AreEqual(GetElement(itemName).Text, product.name);

            Assert.IsTrue(GetElement(itemDescription).Displayed);

            Assert.IsTrue(GetElement(itemPrice).Displayed);

            Assert.IsTrue(GetElement(addToCart).Displayed);
            Assert.AreEqual(GetElement(addToCart).Text, "Add to cart");

            Assert.IsTrue(GetElement(cart).Displayed);
            Assert.IsTrue(GetElement(cart).Text.Length == 0);
        }
    }
}