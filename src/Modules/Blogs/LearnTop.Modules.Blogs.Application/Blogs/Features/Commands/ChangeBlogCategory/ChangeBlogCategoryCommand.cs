using LearnTop.Modules.Blogs.Application.Blogs.Features.Commands.ChangeBlogStatus;
using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Blogs.Features.Commands.ChangeBlogCategory;

public record ChangeBlogCategoryCommand(Guid BlogId, Guid CategoryId)
    : ICommand<ChangeBlogCategoryResponse>;
