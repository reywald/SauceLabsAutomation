namespace SauceLabsAutomation;

public sealed class ShippingConfig
{
    private ShippingConfig() { }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PostalCode { get; set; }
}