using LearnTop.Modules.Blogs.Domain.Blogs.Errors;
using LearnTop.Modules.Blogs.Domain.Blogs.Models;
using LearnTop.Modules.Blogs.Domain.Blogs.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Blogs.Features.Commands.DeleteBlog;

public class DeleteBlogCommandHandler(IBlogRepository blogRepository)
    : ICommandHandler<DeleteBlogCommand, DeleteBlogResponse>
{

    public async Task<Result<DeleteBlogResponse>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        Blog? blog = await blogRepository.GetByIdAsync(request.BlogId);
        if (blog is null)
        {
            return Result.Failure<DeleteBlogResponse>(BlogErrors.NotFound(request.BlogId));
        }
        if (request.IsLogicDelete)
        {
            blog.Delete();
            await blogRepository.UpdateAsync(blog);
        }
        else
        {
            await blogRepository.DeleteAsync(blog);
        }
        return new DeleteBlogResponse(blog.Id);
    }
}
