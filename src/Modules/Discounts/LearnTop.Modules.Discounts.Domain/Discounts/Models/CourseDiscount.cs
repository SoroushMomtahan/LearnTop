using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Discounts.Domain.Discounts.Models;

public class CourseDiscount : Entity
{
    public Guid DiscountId { get; private set; }
    public Guid CourseId { get; private set; }
    public static CourseDiscount Create(Guid discountId, Guid courseId)
    {
        return new()
        {
            DiscountId = discountId,
            CourseId = courseId
        };
    }
}
