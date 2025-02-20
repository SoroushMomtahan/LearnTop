using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Domain.Orders.Models;

public class OrderDetail : Entity
{
    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Price { get; private set; }
    public int Discount { get; private set; }
}
