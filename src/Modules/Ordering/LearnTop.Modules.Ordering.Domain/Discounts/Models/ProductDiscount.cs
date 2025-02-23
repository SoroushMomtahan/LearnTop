using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Domain.Discounts.Models;

public class ProductDiscount : Entity
{
    public Guid DiscountId { get; private set; }
    public Guid ProductId { get; private set; }
    private ProductDiscount() {}
    public static ProductDiscount Create(Guid discountId, Guid courseId)
    {
        return new()
        {
            DiscountId = discountId,
            ProductId = courseId
        };
    }
}
