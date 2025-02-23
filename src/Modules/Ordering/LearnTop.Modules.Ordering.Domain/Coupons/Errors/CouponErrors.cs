using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Domain.Coupons.Errors;

public static class CouponErrors
{
    public static readonly Error InValidExpireTime = new(
        "Coupons.InValidExpireTime",
        "تاریخ انقضای کوپن نمی تواند از زمان فعلی عقب تر باشد.",
        ErrorType.Validation);
    public static readonly Error InValidCeil = new(
        "Coupon.InValidCeil",
        "سقف خرید نمی تواند کمتر یا مساوی کف  خرید باشد.",
        ErrorType.Validation);
    public static readonly Error InValidCeilOrFloor = new(
        "Coupon.InValidCeilOrFloor",
        "سقف و کف خرید نمی توانند کمتر از 50 هزار تومان باشند",
        ErrorType.Validation);
    public static readonly Error NotFound = new(
        "Coupons.NotFound",
        "کوپنی با شناسه ارسالی یافت نشد.",
        ErrorType.NotFound);
}
