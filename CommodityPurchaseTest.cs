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
        Product product = new Product();

        LoginPage loginPage = new(driver);
        loginPage.Visit();
        loginPage.VerifyPage();
        loginPage.Login();

        // Assert.AreEqual("Products", driver.FindElement(By.ClassName("title")).Text);
        // Assert.IsTrue(driver.Url.Contains("inventory.html"));

        // Select a T-Shirt
        ProductsPage productsPage = new(driver, product);
        productsPage.VerifyPage();
        productsPage.SelectProduct("T-Shirt");
        Console.WriteLine(product);

        // Verify the T-shirt details
        ProductPage productPage = new(driver, product);
        Console.WriteLine(product);
        productPage.VerifyPage();

        // Add T-shirt to Cart
        productPage.AddToCart();
        productPage.OpenCart();

        Console.WriteLine(product);

        // Navigate to cart, review and checkout
        CartPage cartPage = new(driver, product);
        cartPage.VerifyPage();
        cartPage.Checkout();

        // Verify checkout
        CheckoutPage checkoutPage = new(driver);
        checkoutPage.VerifyPage();

        // Enter Required checkout information and continue
        checkoutPage.fillForm("Ikechukwu", "Agbarakwe", "112102");
        checkoutPage.Continue();

        // Verify Order Summary page
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