using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Domain.Discounts.Models;

public class CustomerDiscount : Entity
{
    public Guid DiscountId { get; private set; }
    public Guid CustomerId { get; private set; }
    private CustomerDiscount() {}
    public static CustomerDiscount Create(Guid discountId, Guid userId)
    {
        return new()
        {
            DiscountId = discountId,
            CustomerId = userId
        };
    }
}
