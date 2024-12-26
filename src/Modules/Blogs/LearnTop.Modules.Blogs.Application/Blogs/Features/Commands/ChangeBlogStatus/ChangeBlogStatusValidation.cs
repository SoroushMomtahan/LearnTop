using FluentValidation;
using LearnTop.Modules.Blogs.Domain.Blogs.Errors;

namespace LearnTop.Modules.Blogs.Application.Blogs.Features.Commands.ChangeBlogStatus;

public class ChangeBlogStatusValidation : AbstractValidator<ChangeBlogStatusCommand>
{
    public ChangeBlogStatusValidation()
    {
        RuleFor(x => x.Status)
            .NotEmpty()
            .IsInEnum()
            .WithMessage(BlogErrors.StatusIsNotInRange().Description);

        RuleFor(x => x.BlogId)
            .NotEmpty()
            .WithMessage(BlogErrors.Empty("شناسه بلاگ").Description);
    }
}
