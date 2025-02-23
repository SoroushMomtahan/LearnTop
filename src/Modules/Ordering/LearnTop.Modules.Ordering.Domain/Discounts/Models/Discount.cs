using LearnTop.Modules.Ordering.Domain.Discounts.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Domain.Discounts.Models;

public class Discount : Aggregate
{
    public int Percent { get; private set; }
    public DateTime StartAt { get; private set; }
    public DateTime EndAt { get; private set; }
    private readonly List<ProductDiscount> _productDiscounts = [];
    private readonly List<CustomerDiscount> _customerDiscounts = [];
    public IReadOnlyList<ProductDiscount> ProductDiscounts => [.. _productDiscounts];
    public IReadOnlyList<CustomerDiscount> CustomerDiscounts => [.. _customerDiscounts];
    
    private Discount() { }

    public static Result<Discount> Create(
        int percent, 
        DateTime startAt, 
        DateTime endAt)
    {
        if (startAt > endAt)
        {
            return Result.Failure<Discount>(DiscountErrors.StartDateIsAfterEndDate);
        }
        if (percent is < 20 or > 70)
        {
            return Result.Failure<Discount>(DiscountErrors.PercentIsOutOfRange);
        }
        Discount discount = new()
        {
            Percent = percent,
            StartAt = startAt,
            EndAt = endAt
        };
        return discount;
    }
    public void AddProductDiscounts(IReadOnlyList<Guid> courseIds)
    {
        var distinctCourseIds = courseIds.Distinct().ToList();
        var newCourseDiscounts = distinctCourseIds
            .Where(courseId=>_productDiscounts.TrueForAll(x => x.ProductId != courseId))
            .Select(courseId=>ProductDiscount.Create(Id, courseId)).ToList();
        
        _productDiscounts.AddRange(newCourseDiscounts);
    }
    
    public void AddCustomerDiscounts(IReadOnlyList<Guid> userIds)
    {
        var distinctUserIds = userIds.Distinct().ToList();
        var newUserIds = distinctUserIds
            .Where(userId => _customerDiscounts.TrueForAll(x => x.CustomerId != userId))
            .Select(userId=>CustomerDiscount.Create(Id, userId)).ToList();
        
        _customerDiscounts.AddRange(newUserIds);
    }
    public void SubtractProductDiscounts(IReadOnlyList<Guid> courseIds)
    {
        var distinctCourseIds = courseIds.Distinct().ToList();
        _productDiscounts.RemoveAll(x => distinctCourseIds.Any(courseId => courseId == x.ProductId));
    }
    public void SubtractCustomerDiscounts(IReadOnlyList<Guid> userIds)
    {
        var distinctUserIds = userIds.Distinct().ToList();
        _customerDiscounts.RemoveAll(x => distinctUserIds.Any(userId => userId == x.CustomerId));
    }
}
