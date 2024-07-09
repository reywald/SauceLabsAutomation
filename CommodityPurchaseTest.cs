namespace SauceLabsAutomation;

using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceLabsAutomation.Factory;

[TestClass]
public class TShirtPurchaseTest
{
    private static IWebDriver? driver;

    [ClassInitialize]
    public static void SetUp(TestContext testContext) => BrowserFactory.Init("Edge");


    [ClassCleanup]
    public static void TearDown()
    {
        Thread.Sleep(2000);
        BrowserFactory.CloseBrowser();
    }

    [TestMethod]
    public void Purchase()
    {
        driver = BrowserFactory.WebDriver;
        Product product = new();

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
        checkoutPage.FillForm();
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
}