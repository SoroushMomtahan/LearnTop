using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Blogs.Features.Commands.UpdateBlog;

public record UpdateBlogCommand(Guid BlogId, string Title, string Content) : ICommand<UpdateBlogResponse>;
