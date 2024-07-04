using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace SauceLabsAutomation
{
    internal class ProductsPage : BasePage
    {
        public ProductsPage(IWebDriver driver) : base(driver)
        {

            this.SITE_URL += "inventory.html";
        }

        readonly By title = By.ClassName("title");
        readonly By inventory = By.ClassName("inventory_item");
        ReadOnlyCollection<IWebElement>? product_links;

        private Product StoreProduct(IWebElement element) =>
             new Product
             {
                 id = element.GetAttribute("id").Split("_")[1],
                 name = element.Text
             };


        public void SelectProduct(string itemName, ref Product product)
        {
            product_links = GetElements(By.PartialLinkText(itemName));
            Assert.IsTrue(product_links.Count > 0);
            IWebElement tshirt = product_links[0];
            product = StoreProduct(tshirt);

            tshirt.Click();
        }

        public override void VerifyPage()
        {
            Assert.AreEqual(SITE_URL, webDriver.Url);
            Assert.AreEqual("Swag Labs", webDriver.Title);
            Assert.IsTrue(GetElement(title).Displayed);
            Assert.IsTrue(GetElements(inventory).Count == 6);
        }
    }
}
