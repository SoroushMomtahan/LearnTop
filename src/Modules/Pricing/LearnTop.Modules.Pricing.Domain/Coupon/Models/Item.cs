using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Pricing.Coupon.Models;

public class Item : Entity
{
    public Guid ProductId { get; private set; }
}
