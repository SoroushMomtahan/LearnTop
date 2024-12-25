using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Pricing.Coupon.Models;

public class Coupon : Aggregate
{
    private readonly List<Item> _couponItems = [];
    public IReadOnlyList<Item> CouponItems => [.. _couponItems];
    private readonly List<Customer> _couponCustomers = [];
    public IReadOnlyList<Customer> CouponCustomers => [.. _couponCustomers];
    public string Code { get; private set; }
    public DateTime StartAt { get; private set; }
    public DateTime EndAt { get; private set; }
}
