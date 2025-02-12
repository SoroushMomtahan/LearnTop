using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Categories.Application.Categories.Features.Commands.AddParentCategory;

public record AddParentCategoryCommand(
    Guid ParentCategoryId, 
    Guid CategoryId) : ICommand<AddParentCategoryResponse>;
