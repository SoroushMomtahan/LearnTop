using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Blogs.Features.Commands.DeleteBlog;

public record DeleteBlogCommand(Guid BlogId, bool IsLogicDelete) : ICommand<DeleteBlogResponse>;
