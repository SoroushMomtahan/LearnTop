using LearnTop.Modules.Pricing.products.ValueObjects;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Pricing.products.Models;

public class Store : Aggregate
{
    private readonly List<Product> _products = [];
    public IReadOnlyList<Product> Products => [.. _products];
    public Discount FestivalDiscount { get; private set; }
}
