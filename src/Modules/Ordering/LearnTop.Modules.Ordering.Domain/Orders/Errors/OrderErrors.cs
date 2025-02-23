using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Domain.Orders.Errors;

public static class OrderErrors
{
    public static readonly Error CouponOutOfRange = new(
        "Orders.CouponOutOfRange",
        "کوپن نمی تواند کمتر از 20 درصد یا بیشتر از 70 درصد باشد.",
        ErrorType.Validation);

    public static readonly Error NotFound = new(
        "Orders.NotFound",
        "سفارشی با شناسه ارسالی یافت نشد",
        ErrorType.NotFound);
}
