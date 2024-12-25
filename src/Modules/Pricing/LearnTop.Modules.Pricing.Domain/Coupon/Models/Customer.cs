using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Pricing.Coupon.Models;

public class Customer : Entity
{
    public Guid CustomerId { get; private set; }
}
