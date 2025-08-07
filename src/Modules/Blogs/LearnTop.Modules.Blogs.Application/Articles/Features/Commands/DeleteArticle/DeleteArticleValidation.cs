using FluentValidation;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.DeleteArticle;

public class DeleteArticleValidation : AbstractValidator<DeleteArticleCommand>
{
    public DeleteArticleValidation()
    {
        RuleFor(x => x.ArticleId)
            .NotEmpty()
            .WithMessage(Error.Empty("شناسه بلاگ").Description);
    }
}
