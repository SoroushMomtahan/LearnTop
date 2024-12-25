using LearnTop.Modules.Pricing.products.ValueObjects;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Pricing.products.Models;

public class FriendDiscount : Entity
{
    public Guid FriendId { get; private set; }
    public Guid ProductId { get; private set; }
    public Discount Discount { get; private set; }
}
