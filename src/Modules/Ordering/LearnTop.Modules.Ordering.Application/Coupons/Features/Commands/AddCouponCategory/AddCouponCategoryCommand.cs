using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Ordering.Application.Coupons.Features.Commands.AddCouponCategory;

public record AddCouponCategoryCommand(
    Guid CategoryId,
    Guid CouponId) : ICommand<AddCouponCategoryResponse>;
