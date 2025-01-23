using FluentValidation;

namespace Tagging.Tags.Features.CreateTag;

internal sealed class CreateTagValidation : AbstractValidator<CreateTagCommand>
{
    public CreateTagValidation()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage(Errors.TagErrors.TitleIsEmpty.Description);

        RuleFor(x => x.Description)
            .MinimumLength(3)
            .WithMessage(Errors.TagErrors.DescriptionLessThan3Character.Description);
    }
}
