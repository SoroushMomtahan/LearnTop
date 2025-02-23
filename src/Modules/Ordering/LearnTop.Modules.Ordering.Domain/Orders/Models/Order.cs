using LearnTop.Modules.Ordering.Domain.Coupons.Models;
using LearnTop.Modules.Ordering.Domain.Orders.Enums;
using LearnTop.Modules.Ordering.Domain.Orders.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Domain.Orders.Models;

public class Order : Aggregate
{
    public Guid CustomerId { get; private set; }
    public long TotalPrice { get; private set; }
    public int CouponPercent { get; private set; }
    public OrderStatus OrderStatus { get; private set; }
    private readonly List<OrderItem> _items = [];
    public IReadOnlyList<OrderItem> Items => [.. _items];
    private Order() {}
    public static Order Create(Guid customerId)
    {
        Order order = new()
        {
            CustomerId = customerId,
            OrderStatus = OrderStatus.Pending,
        };
        
        return order;
    }
    public Result AddOrderItem(Guid productId, long price, int percentDiscount)
    {
        Result<OrderItem> result = OrderItem.Create(Id, productId, price, percentDiscount);
        if (result.IsFailure)
        {
            return Result.Failure<OrderItem>(result.Error);
        }
        _items.Add(result.Value);
        SetTotalPrice();
        return Result.Success();
    }
    public void ChangeOrderStatus(OrderStatus orderStatus)
    {
        OrderStatus = orderStatus;
    }
    public Result AddCouponPercent(int percentOfCouponDiscount)
    {
        if (percentOfCouponDiscount is < 20 or > 70)
        {
            return Result.Failure(OrderErrors.CouponOutOfRange);
        }
        CouponPercent = percentOfCouponDiscount;
        SetTotalPrice();
        return Result.Success();
    }
    private void SetTotalPrice()
    {
        long totalPriceWithoutCouponDiscount = Items
            .Sum(item => item.Price * (100 - item.PercentDiscount) / 100);
        
        TotalPrice = totalPriceWithoutCouponDiscount * (100 - CouponPercent) / 100;
    }
}
