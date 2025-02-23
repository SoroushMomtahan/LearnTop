using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Domain.Discounts.Errors;

public static class DiscountErrors
{
    public static readonly Error PercentIsOutOfRange = new(
        "Discounts.PercentIsOutOfRange",
        "میزان تخفیف باید بین 20 تا 70 درصد باشد.",
        ErrorType.Validation);
    public static readonly Error StartDateIsAfterEndDate = new(
        "Discounts.StartDateIsAfterEndDate",
        "تاریخ شروع باید قبل از تاریخ پایان باشد.",
        ErrorType.Validation);
    public static readonly Error EmptyListOfCourse = new(
        "Discounts.EmptyListOfCourse",
        "حداقل یک درس باید انتخاب شود",
        ErrorType.Validation);
}
