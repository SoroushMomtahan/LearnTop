using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Categories.Application.Categories.Features.Commands.AddChildCategory;

public record AddChildCategoryCommand(
    Guid ChildCategoryId,
    Guid CategoryId) : ICommand<AddChildCategoryResponse>;
