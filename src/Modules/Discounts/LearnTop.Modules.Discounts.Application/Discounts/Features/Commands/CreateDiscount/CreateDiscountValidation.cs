using FluentValidation;
using LearnTop.Modules.Discounts.Domain.Discounts.Errors;

namespace LearnTop.Modules.Discounts.Application.Discounts.Features.Commands.CreateDiscount;

internal sealed class CreateDiscountValidation : AbstractValidator<CreateDiscountCommand>
{
    public CreateDiscountValidation()
    {
        RuleFor(x=>x.Percent)
            .GreaterThan(21).WithMessage(DiscountErrors.PercentIsOutOfRange.Description)
            .LessThan(71).WithMessage(DiscountErrors.PercentIsOutOfRange.Description);
    }
}
