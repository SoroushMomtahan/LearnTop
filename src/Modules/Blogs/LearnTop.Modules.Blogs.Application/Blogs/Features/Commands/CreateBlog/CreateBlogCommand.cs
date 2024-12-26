using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Blogs.Features.Commands.CreateBlog;

public record CreateBlogCommand(
    Guid AuthorId,
    Guid CategoryId,
    string Title, 
    string Content
    ) : ICommand<CreateBlogResponse>;
