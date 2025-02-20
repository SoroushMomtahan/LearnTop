using LearnTop.Modules.Ordering.Domain.Orders.Enums;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Domain.Orders.Models;

public class Order : Aggregate
{
    public Guid CustomerId { get; private set; }
    public int TotalPrice { get; private set; }
    public int TotalPriceAfterDiscount { get; private set; }
    public int TotalCount { get; private set; }
    public OrderStatus OrderStatus { get; private set; }
    private readonly List<OrderDetail> _orderDetails = [];
    public IReadOnlyList<OrderDetail> OrderDetails => [.. _orderDetails];
}
