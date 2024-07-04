namespace SauceLabsAutomation;

using System.Threading;
using OpenQA.Selenium.Chrome;

[TestClass]
public class TShirtPurchaseTest
{
    // readonly static string SITE_URL = "https://www.saucedemo.com/";
    static ChromeDriver? driver;

    [ClassInitialize]
    public static void SetUp(TestContext testContext)
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArguments("--incognito", "--start-maximized");
        driver = new ChromeDriver(options);
    }

    [ClassCleanup]
    public static void TearDown()
    {
        Thread.Sleep(2000);
        driver?.Quit();
    }


    [TestMethod]
    public void Purchase()
    {
        ChromeDriver driver = GetDriver();
        LoginPage loginPage = new LoginPage(driver);
        loginPage.Visit();
        loginPage.VerifyPage();
        loginPage.Login();

        // // Select a T-Shirt
        ProductsPage productsPage = new ProductsPage(driver);
        productsPage.VerifyPage();
        productsPage.SelectProduct("T-Shirt");
        // Assert.AreEqual("Products", driver.FindElement(By.ClassName("title")).Text);
        // Assert.IsTrue(driver.Url.Contains("inventory.html"));

        // // Select a T-Shirt
        // ReadOnlyCollection<IWebElement> products = driver.FindElements(By.PartialLinkText("T-Shirt"));
        // Assert.IsTrue(products.Count == 2);
        // IWebElement tshirt = products[0];
        // string itemId = tshirt.GetAttribute("id").Split("_")[1];
        // string itemName = tshirt.Text;
        // tshirt.Click();

        // // Verify the T-shirt details
        // Assert.IsTrue(driver.Url.Contains(itemId));
        // Assert.AreEqual(driver.FindElement(By.ClassName("inventory_details_name")).Text, itemName);

        // string item_name = driver.FindElement(By.ClassName("inventory_details_name")).Text;
        // string item_description = driver.FindElement(By.ClassName("inventory_details_desc")).Text;
        // string item_price = driver.FindElement(By.ClassName("inventory_details_price")).Text;

        // // Add T-shirt to Cart
        // IWebElement addToCart = driver.FindElement(By.ClassName("btn_inventory"));
        // IWebElement cart = driver.FindElement(By.Id("shopping_cart_container"));
        // // Assert.IsTrue(addToCart.Text == "Add to cart");
        // Assert.IsTrue(cart.Text.Length == 0);

        // addToCart.Click();
        // // Assert.IsTrue(addToCart.Text == "Remove");
        // Assert.IsTrue(cart.Text == "1");

        // // Navigate to cart
        // cart.Click();
        // Assert.IsTrue(driver.Url.Contains("cart.html"));
        // Assert.IsTrue(driver.FindElement(By.ClassName("title")).Text.Contains("Your Cart"));

        // string cart_qty = driver.FindElement(By.ClassName("cart_quantity")).Text;
        // string cart_name = driver.FindElement(By.ClassName("inventory_item_name")).Text;
        // string cart_description = driver.FindElement(By.ClassName("inventory_item_desc")).Text;
        // string cart_price = driver.FindElement(By.ClassName("inventory_item_price")).Text;

        // // Review cart details
        // Assert.AreEqual(cart_name, item_name);
        // Assert.AreEqual(cart_description, item_description);
        // Assert.AreEqual(cart_price, item_price);
        // Assert.AreEqual(cart_qty, "1");

        // // Checkout and verify
        // driver.FindElement(By.Id("checkout")).Click();
        // Assert.IsTrue(driver.Url.Contains("checkout-step-one.html"));
        // Assert.IsTrue(driver.FindElement(By.ClassName("title")).Text.Contains("Checkout: Your Information"));

        // // Enter Required checkout information
        // driver.FindElement(By.Id("first-name")).Clear();
        // driver.FindElement(By.Id("first-name")).SendKeys("Ikechukwu");
        // driver.FindElement(By.Id("last-name")).Clear();
        // driver.FindElement(By.Id("last-name")).SendKeys("Agbarakwe");
        // driver.FindElement(By.Id("postal-code")).Clear();
        // driver.FindElement(By.Id("postal-code")).SendKeys("112102");
        // driver.FindElement(By.Id("continue")).Click();

        // // Verify Order Summary page
        // Assert.IsTrue(driver.Url.Contains("checkout-step-two.html"));
        // Assert.IsTrue(driver.FindElement(By.ClassName("title")).Text.Contains("Checkout: Overview"));

        // string checkout_qty = driver.FindElement(By.ClassName("cart_quantity")).Text;
        // string checkout_name = driver.FindElement(By.ClassName("inventory_item_name")).Text;
        // string checkout_description = driver.FindElement(By.ClassName("inventory_item_desc")).Text;
        // string checkout_price = driver.FindElement(By.ClassName("inventory_item_price")).Text;
        // string checkout_price_total = driver.FindElement(By.ClassName("summary_subtotal_label")).Text;
        // string checkout_tax = driver.FindElement(By.ClassName("summary_tax_label")).Text;
        // string checkout_total = driver.FindElement(By.ClassName("summary_total_label")).Text;

        // // Review checkout details
        // Assert.AreEqual(checkout_qty, cart_qty);
        // Assert.AreEqual(checkout_name, item_name);
        // Assert.AreEqual(checkout_description, item_description);
        // Assert.AreEqual(checkout_price, item_price);
        // Assert.IsTrue(checkout_price_total.Contains(checkout_price));

        // double itemPrice = Convert.ToDouble(checkout_price.Substring(1));
        // double tax = Convert.ToDouble(checkout_tax.Substring(6));
        // double total = Convert.ToDouble(checkout_total.Substring(8));
        // Assert.IsTrue((itemPrice + tax) == total);

        // // Finalize Purchase
        // driver.FindElement(By.Id("finish")).Click();

        // // Verify Order Summary page
        // Assert.IsTrue(driver.Url.Contains("checkout-complete.html"));
        // Assert.IsTrue(driver.FindElement(By.ClassName("title")).Text.Contains("Checkout: Complete!"));
        // Assert.AreEqual(driver.FindElement(By.ClassName("complete-header")).Text, "Thank you for your order!");
        // Assert.IsTrue(driver.FindElement(By.ClassName("complete-text")).Text.Contains("Your order has been dispatched"));

        // // Logout
        // driver.FindElement(By.Id("back-to-products")).Click();
        // driver.FindElement(By.Id("react-burger-menu-btn")).Click();
        // Thread.Sleep(1000);
        // driver.FindElement(By.Id("logout_sidebar_link")).Click();

        // // Verify Login Page
        // Assert.AreEqual(SITE_URL, driver.Url);
        // Assert.AreEqual("Swag Labs", driver.Title);
    }

    private static ChromeDriver GetDriver()
    {
        return driver ?? throw new NullReferenceException("Driver has not been initialized");
    }
}