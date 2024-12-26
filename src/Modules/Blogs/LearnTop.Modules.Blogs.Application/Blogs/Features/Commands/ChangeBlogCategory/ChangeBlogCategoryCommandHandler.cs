using LearnTop.Modules.Blogs.Domain.Blogs.Errors;
using LearnTop.Modules.Blogs.Domain.Blogs.Models;
using LearnTop.Modules.Blogs.Domain.Blogs.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Blogs.Features.Commands.ChangeBlogCategory;

public class ChangeBlogCategoryCommandHandler(IBlogRepository blogRepository)
    : ICommandHandler<ChangeBlogCategoryCommand, ChangeBlogCategoryResponse>
{

    public async Task<Result<ChangeBlogCategoryResponse>> Handle(ChangeBlogCategoryCommand request, CancellationToken cancellationToken)
    {
        // TODO: Find Category Wth CategoryId
        
        Blog? blog = await blogRepository.GetByIdAsync(request.BlogId);
        if (blog is null)
        {
            return Result.Failure<ChangeBlogCategoryResponse>(BlogErrors.NotFound(request.BlogId));
        }
        blog.ChangeCategory(request.CategoryId);
        await blogRepository.UpdateAsync(blog);
        return new ChangeBlogCategoryResponse(blog.Id);
    }
}
