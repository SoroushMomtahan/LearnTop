using LearnTop.Modules.Pricing.products.Enums;
using LearnTop.Modules.Pricing.products.ValueObjects;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Pricing.products.Models;

public class Product : Entity
{
    public Guid ProductId { get; private set; }
    public string Price { get; private set; }
    public Status Status { get; private set; }
    public Discount Discount { get; private set; }
    private readonly List<FriendDiscount> _friendDiscounts = [];
    public IReadOnlyList<FriendDiscount> FriendDiscounts => [.. _friendDiscounts];
}
