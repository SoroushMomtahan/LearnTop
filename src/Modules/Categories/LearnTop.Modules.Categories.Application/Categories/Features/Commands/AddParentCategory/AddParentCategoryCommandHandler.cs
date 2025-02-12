using LearnTop.Modules.Categories.Application.Abstractions.Data;
using LearnTop.Modules.Categories.Domain.Categories.Errors;
using LearnTop.Modules.Categories.Domain.Categories.Models;
using LearnTop.Modules.Categories.Domain.Categories.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Categories.Application.Categories.Features.Commands.AddParentCategory;

internal sealed class AddParentCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<AddParentCategoryCommand, AddParentCategoryResponse>
{

    public async Task<Result<AddParentCategoryResponse>> Handle(
        AddParentCategoryCommand request, 
        CancellationToken cancellationToken)
    {
        Category? category = await categoryRepository.GetAsync(request.CategoryId, cancellationToken);
        if (category is null)
        {
            return Result.Failure<AddParentCategoryResponse>(CategoryErrors.NotFound);
        }
        
        Category? parentCategory = await categoryRepository.GetAsync(request.ParentCategoryId, cancellationToken);
        if (parentCategory is null)
        {
            return Result.Failure<AddParentCategoryResponse>(CategoryErrors.NotFound);
        }
        
        Result<CategoryRelation> categoryRelationResult = CategoryRelation.Create(parentCategory.Id, category.Id);
        if (categoryRelationResult.IsFailure)
        {
            return Result.Failure<AddParentCategoryResponse>(categoryRelationResult.Error);
        }
        
        Result addParentResult = category.AddParentCategory(categoryRelationResult.Value);
        if (addParentResult.IsFailure)
        {
            return Result.Failure<AddParentCategoryResponse>(addParentResult.Error);
        }
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return new AddParentCategoryResponse();
    }
}
