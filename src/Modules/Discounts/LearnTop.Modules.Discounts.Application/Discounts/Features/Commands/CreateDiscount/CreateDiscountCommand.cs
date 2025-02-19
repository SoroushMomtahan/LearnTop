using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Discounts.Application.Discounts.Features.Commands.CreateDiscount;

public record CreateDiscountCommand(
    int Percent,
    DateTime StartAt,
    DateTime EndAt,
    IReadOnlyList<Guid> CourseIds,
    IReadOnlyList<Guid> UserIds) : ICommand<CreateDiscountResponse>;
