namespace LearnTop.Modules.Pricing.products.ValueObjects;

public class Discount
{
    public string Percent { get; private set; }
    public DateTime StartAt { get; private set; }
    public DateTime EndAt { get; private set; }
}
