namespace SauceLabsAutomation
{
    public record struct Product(
        string id,
        string name,
        string description,
        string price
    );
}