using FluentValidation;
using LearnTop.Modules.Blogs.Domain.Blogs.Errors;

namespace LearnTop.Modules.Blogs.Application.Blogs.Features.Commands.UpdateBlog;

internal sealed class UpdateBlogValidation : AbstractValidator<UpdateBlogCommand>
{
    public UpdateBlogValidation()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage(BlogErrors.TitleIsLessThan3Characters().Description);
        
        RuleFor(x => x.Title)
            .MaximumLength(100)
            .WithMessage(BlogErrors.TitleIsGreaterThan100Characters().Description);
        
        RuleFor(x => x.Content)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage(BlogErrors.ContentIsLessThan3Characters().Description);

        RuleFor(x => x.BlogId)
            .NotEmpty()
            .WithMessage(BlogErrors.Empty("شناسه بلاگ").Description);
    }
}
