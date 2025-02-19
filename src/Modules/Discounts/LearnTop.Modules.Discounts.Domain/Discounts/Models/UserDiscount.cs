using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Discounts.Domain.Discounts.Models;

public class UserDiscount : Entity
{
    public Guid DiscountId { get; private set; }
    public Guid UserId { get; private set; }
    public static UserDiscount Create(Guid discountId, Guid userId)
    {
        return new()
        {
            DiscountId = discountId,
            UserId = userId
        };
    }
}
