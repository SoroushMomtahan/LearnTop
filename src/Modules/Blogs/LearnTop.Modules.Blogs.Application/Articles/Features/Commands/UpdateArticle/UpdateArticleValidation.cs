using FluentValidation;
using LearnTop.Modules.Blogs.Domain.Articles.Errors;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.UpdateArticle;

internal sealed class UpdateArticleValidation : AbstractValidator<UpdateArticleCommand>
{
    public UpdateArticleValidation()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage(ArticleErrors.TitleIsLessThan3Characters().Description);
        
        RuleFor(x => x.Title)
            .MaximumLength(100)
            .WithMessage(ArticleErrors.TitleIsGreaterThan100Characters().Description);
        
        RuleFor(x => x.Content)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage(ArticleErrors.ContentIsLessThan3Characters().Description);

        RuleFor(x => x.ArticleId)
            .NotEmpty()
            .WithMessage(ArticleErrors.Empty("شناسه بلاگ").Description);
    }
}
