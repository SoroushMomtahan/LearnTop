using LearnTop.Modules.Blogs.Domain.Blogs.Models;
using LearnTop.Modules.Blogs.Domain.Blogs.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Blogs.Features.Commands.CreateBlog;

internal sealed class CreateBlogCommandHandler(IBlogRepository blogRepository) 
    : ICommandHandler<CreateBlogCommand, CreateBlogResponse>
{

    public async Task<Result<CreateBlogResponse>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        // TODO: Find Author With AuthorId
        // TODO: Find Category With CategoryId
        
        Result<Blog> blog = Blog.Create(
            request.AuthorId,
            request.CategoryId,
            request.Title,
            request.Content
            );
        if (blog.IsFailure)
        {
            return Result.Failure<CreateBlogResponse>(blog.Error);
        }
        await blogRepository.CreateAsync(blog.Value);
        return new CreateBlogResponse(blog.Value.Id);
    }
}
