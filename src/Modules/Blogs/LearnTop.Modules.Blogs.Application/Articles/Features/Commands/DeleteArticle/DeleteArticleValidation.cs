using FluentValidation;
using LearnTop.Modules.Blogs.Domain.Articles.Errors;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.DeleteArticle;

public class DeleteArticleValidation : AbstractValidator<DeleteArticleCommand>
{
    public DeleteArticleValidation()
    {
        RuleFor(x => x.BlogId)
            .NotEmpty()
            .WithMessage(ArticleErrors.Empty("شناسه بلاگ").Description);
    }
}
