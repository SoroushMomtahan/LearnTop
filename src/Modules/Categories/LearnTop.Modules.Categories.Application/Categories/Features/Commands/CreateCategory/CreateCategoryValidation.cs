using FluentValidation;

namespace LearnTop.Modules.Categories.Application.Categories.Features.Commands.CreateCategory;

public class CreateCategoryValidation : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}
