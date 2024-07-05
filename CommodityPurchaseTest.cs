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

        // Verify Order Summary page and review checkout details
        OrderSummaryPage orderSummaryPage = new(driver, product);
        orderSummaryPage.VerifyPage();

        // Finalize Purchase
        orderSummaryPage.Finish();

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