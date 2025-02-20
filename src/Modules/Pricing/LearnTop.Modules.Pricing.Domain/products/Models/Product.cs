using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Pricing.products.Models;

public class Product : Aggregate
{
    public Guid ProductId { get; private set; }
    public string Price { get; private set; }
}
