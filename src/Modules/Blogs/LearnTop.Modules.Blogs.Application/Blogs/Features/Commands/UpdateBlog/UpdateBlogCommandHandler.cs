using LearnTop.Modules.Blogs.Domain.Blogs.Errors;
using LearnTop.Modules.Blogs.Domain.Blogs.Models;
using LearnTop.Modules.Blogs.Domain.Blogs.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Blogs.Features.Commands.UpdateBlog;

internal sealed class UpdateBlogCommandHandler(IBlogRepository blogRepository) 
    :ICommandHandler<UpdateBlogCommand, UpdateBlogResponse>
{

    public async Task<Result<UpdateBlogResponse>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        Blog? blog = await blogRepository.GetByIdAsync(request.BlogId);
        if (blog is null)
        {
            return Result.Failure<UpdateBlogResponse>(BlogErrors.NotFound(request.BlogId));
        }
        blog.Update(
            request.Title,
            request.Content
            );
        await blogRepository.UpdateAsync(blog);
        return new UpdateBlogResponse(blog.Id);
    }
}
