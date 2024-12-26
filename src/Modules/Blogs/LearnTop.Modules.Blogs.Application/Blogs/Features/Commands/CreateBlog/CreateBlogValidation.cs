using FluentValidation;
using LearnTop.Modules.Blogs.Domain.Blogs.Errors;

namespace LearnTop.Modules.Blogs.Application.Blogs.Features.Commands.CreateBlog;

internal sealed class CreateBlogValidation : AbstractValidator<CreateBlogCommand>
{
    public CreateBlogValidation()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage(BlogErrors.TitleIsLessThan3Characters().Description);
        
        RuleFor(x=>x.Title)
            .MaximumLength(100)
            .WithMessage(BlogErrors.TitleIsGreaterThan100Characters().Description);
        
        RuleFor(x=>x.Content)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage(BlogErrors.ContentIsLessThan3Characters().Description);

        RuleFor(x => x.AuthorId)
            .NotEmpty()
            .WithMessage(BlogErrors.Empty("شناسه نویسنده").Description);

        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage(BlogErrors.Empty("شناسه دسته بندی").Description);
    }
}
