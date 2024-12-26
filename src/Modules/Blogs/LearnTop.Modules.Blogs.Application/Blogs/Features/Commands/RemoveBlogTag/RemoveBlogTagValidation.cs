using FluentValidation;
using LearnTop.Modules.Blogs.Domain.Blogs.Errors;

namespace LearnTop.Modules.Blogs.Application.Blogs.Features.Commands.RemoveBlogTag;

internal sealed class RemoveBlogTagValidation : AbstractValidator<RemoveBlogTagCommand>
{
    public RemoveBlogTagValidation()
    {
        RuleFor(x => x.BlogId)
            .NotEmpty()
            .WithMessage(BlogErrors.Empty("شناسه بلاگ").Description);

        RuleFor(x => x.TagId)
            .NotEmpty()
            .WithMessage(BlogErrors.Empty("شناسه تگ").Description);
    }
}
