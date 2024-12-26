using FluentValidation;
using LearnTop.Modules.Blogs.Domain.Articles.Errors;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.CreateArticle;

internal sealed class CreateArticleValidation : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleValidation()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage(ArticleErrors.TitleIsLessThan3Characters().Description);
        
        RuleFor(x=>x.Title)
            .MaximumLength(100)
            .WithMessage(ArticleErrors.TitleIsGreaterThan100Characters().Description);
        
        RuleFor(x=>x.Content)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage(ArticleErrors.ContentIsLessThan3Characters().Description);

        RuleFor(x => x.AuthorId)
            .NotEmpty()
            .WithMessage(ArticleErrors.Empty("شناسه نویسنده").Description);

        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage(ArticleErrors.Empty("شناسه دسته بندی").Description);
    }
}
