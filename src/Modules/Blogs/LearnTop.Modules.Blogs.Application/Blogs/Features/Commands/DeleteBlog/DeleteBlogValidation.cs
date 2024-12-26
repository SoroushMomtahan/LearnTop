using FluentValidation;
using LearnTop.Modules.Blogs.Domain.Blogs.Errors;

namespace LearnTop.Modules.Blogs.Application.Blogs.Features.Commands.DeleteBlog;

public class DeleteBlogValidation : AbstractValidator<DeleteBlogCommand>
{
    public DeleteBlogValidation()
    {
        RuleFor(x => x.BlogId)
            .NotEmpty()
            .WithMessage(BlogErrors.Empty("شناسه بلاگ").Description);
    }
}
