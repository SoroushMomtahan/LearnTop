using FluentValidation;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.RemoveArticleTag;

internal sealed class RemoveArticleTagValidation : AbstractValidator<RemoveArticleTagCommand>
{
    public RemoveArticleTagValidation()
    {
        RuleFor(x => x.ArticleId)
            .NotEmpty()
            .WithMessage(Error.Empty("شناسه بلاگ").Description);

        RuleFor(x => x.TagId)
            .NotEmpty()
            .WithMessage(Error.Empty("شناسه تگ").Description);
    }
}
