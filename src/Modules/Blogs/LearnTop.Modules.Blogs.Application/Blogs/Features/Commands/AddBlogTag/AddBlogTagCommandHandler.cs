using LearnTop.Modules.Blogs.Domain.Blogs.Errors;
using LearnTop.Modules.Blogs.Domain.Blogs.Models;
using LearnTop.Modules.Blogs.Domain.Blogs.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Blogs.Features.Commands.AddBlogTag;

internal sealed class AddBlogTagCommandHandler(IBlogRepository blogRepository)
    : ICommandHandler<AddBlogTagCommand, AddBlogTagResponse>
{

    public async Task<Result<AddBlogTagResponse>> Handle(AddBlogTagCommand request, CancellationToken cancellationToken)
    {
        
        Blog? blog = await blogRepository.GetByIdAsync(request.BlogId);
        if (blog is null)
        {
            return Result.Failure<AddBlogTagResponse>(BlogErrors.NotFound(request.BlogId));
        }
        
        // TODO: Find Tags With TagIds
        
        blog.AddTag(new(request.TagId, request.BlogId));

        await blogRepository.UpdateTagsAsync(blog);
        return new AddBlogTagResponse(blog.Id);
    }
}
