using FluentValidation;
using LearnTop.Modules.Blogs.Domain.Articles.Errors;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.ChangeArticleStatus;

public class ChangeArticleStatusValidation : AbstractValidator<ChangeArticleStatusCommand>
{
    public ChangeArticleStatusValidation()
    {
        RuleFor(x => x.Status)
            .NotEmpty()
            .IsInEnum()
            .WithMessage(ArticleErrors.StatusIsNotInRange().Description);

        RuleFor(x => x.BlogId)
            .NotEmpty()
            .WithMessage(ArticleErrors.Empty("شناسه بلاگ").Description);
    }
}
