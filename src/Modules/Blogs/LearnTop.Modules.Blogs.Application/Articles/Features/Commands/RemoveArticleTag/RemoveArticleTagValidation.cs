using FluentValidation;
using LearnTop.Modules.Blogs.Domain.Articles.Errors;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.RemoveArticleTag;

internal sealed class RemoveArticleTagValidation : AbstractValidator<RemoveArticleTagCommand>
{
    public RemoveArticleTagValidation()
    {
        RuleFor(x => x.ArticleId)
            .NotEmpty()
            .WithMessage(ArticleErrors.Empty("شناسه بلاگ").Description);

        RuleFor(x => x.TagId)
            .NotEmpty()
            .WithMessage(ArticleErrors.Empty("شناسه تگ").Description);
    }
}
