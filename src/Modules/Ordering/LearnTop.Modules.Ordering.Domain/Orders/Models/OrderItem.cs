using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Domain.Orders.Models;

public class OrderItem : Entity
{
    public Guid OrderId { get; private set; }
    public Guid CourseId { get; private set; }
    public long Price { get; private set; }
    public int PercentDiscount { get; private set; }
    private OrderItem() { }

    public static OrderItem Create(Guid orderId, Guid courseId, long price, int percentDiscount)
    {
        return new()
        {
            OrderId = orderId,
            CourseId = courseId,
            Price = price,
            PercentDiscount = percentDiscount
        };
    }
}
