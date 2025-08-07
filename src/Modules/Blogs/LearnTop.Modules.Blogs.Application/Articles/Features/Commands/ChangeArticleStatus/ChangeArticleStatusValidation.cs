using FluentValidation;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.ChangeArticleStatus;

public class ChangeArticleStatusValidation : AbstractValidator<ChangeArticleStatusCommand>
{
    public ChangeArticleStatusValidation()
    {
        RuleFor(x => x.Status)
            .NotEmpty()
            .IsInEnum()
            .WithMessage(ArticleErrors.StatusIsNotInRange().Description);

        RuleFor(x => x.ArticleId)
            .NotEmpty()
            .WithMessage(Error.Empty("شناسه بلاگ").Description);
    }
}
