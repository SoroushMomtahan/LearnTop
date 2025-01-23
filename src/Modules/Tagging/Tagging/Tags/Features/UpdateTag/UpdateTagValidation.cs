using FluentValidation;
using Tagging.Tags.Errors;

namespace Tagging.Tags.Features.UpdateTag;

public class UpdateTagValidation : AbstractValidator<UpdateTagCommand>
{
    public UpdateTagValidation()
    {
        RuleFor(x => x.Description)
            .MinimumLength(3)
            .WithMessage(TagErrors.DescriptionLessThan3Character.Description);

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage(TagErrors.TitleIsEmpty.Description);
    }
}
