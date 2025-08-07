using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Categories.Features.Commands.CreateCategory;

public record CreateCategoryCommand(Guid CategoryId, string Name) : ICommand;
