using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Categories.Application.Categories.Features.Commands.CreateCategory;

public record CreateCategoryCommand(
    string Name,
    int Order,
    string? Description,
    string? LightImage,
    string? DarkImage,
    string? Icon
    )
    : ICommand<CreateCategoryResponse>;
