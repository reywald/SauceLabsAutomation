namespace SauceLabsAutomation;

public sealed class URLConfig
{
    private URLConfig() { }

    public required string BaseURL { get; set; }
    public required string ProductsURL { get; set; }
    public required string ProductURL { get; set; }
    public required string CartURL { get; set; }
    public required string Checkout1URL { get; set; }
    public required string Checkout2URL { get; set; }
    public required string CheckoutFinalURL { get; set; }
}
