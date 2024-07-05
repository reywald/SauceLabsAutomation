using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace SauceLabsAutomation
{
    internal class ProductsPage : BasePage
    {
        public ProductsPage(IWebDriver driver, Product product) : base(driver)
        {

            this.product = product;
            this.SITE_URL += "inventory.html";
        }

        Product product;

        readonly By title = By.ClassName("title");
        readonly By inventory = By.ClassName("inventory_item");
        ReadOnlyCollection<IWebElement>? product_links;
        IWebElement? selectedProduct;

        public void SelectProduct(string itemName)
        {
            product_links = GetElements(By.PartialLinkText(itemName));
            Assert.IsTrue(product_links.Count > 0);
            selectedProduct = product_links[0];

            // Store the product contents
            StoreProduct();

            selectedProduct.Click();
        }

        protected override void StoreProduct()
        {
            if (selectedProduct != null)
            {
                product.id = selectedProduct.GetAttribute("id").Split("_")[1];
                product.name = selectedProduct.Text;
                Console.WriteLine($"In ProductsPage: {product}");
            }
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
