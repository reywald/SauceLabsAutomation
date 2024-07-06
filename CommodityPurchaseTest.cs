namespace SauceLabsAutomation;

using System.Threading;
using OpenQA.Selenium.Chrome;

[TestClass]
public class TShirtPurchaseTest
{
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
        loginPage.CheckLoggedIn();

        // Select a T-Shirt
        ProductsPage productsPage = new(driver, product);
        productsPage.VerifyPage();
        productsPage.SelectProduct("T-Shirt");

        // Verify the T-shirt details
        ProductPage productPage = new(driver, product);
        productPage.VerifyPage();

        // Add T-shirt to Cart
        productPage.AddToCart();
        productPage.OpenCart();

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

        // Verify Order Completion page
        OrderCompletionPage completionPage = new(driver);
        completionPage.VerifyPage();
        completionPage.Close();

        // Logout
        MenuFragment menu = new(driver);
        menu.Logout();

        // Verify Login Page
        loginPage.VerifyPage();
    }

    private static ChromeDriver GetDriver()
    {
        return driver ?? throw new NullReferenceException("Driver has not been initialized");
    }
}