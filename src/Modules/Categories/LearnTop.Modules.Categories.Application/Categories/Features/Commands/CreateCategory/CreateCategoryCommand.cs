using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Categories.Application.Categories.Features.Commands.CreateCategory;

public record CreateCategoryCommand(
    string Name,
    string? Description
    )
    : ICommand<CreateCategoryResponse>;
