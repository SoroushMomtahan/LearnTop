using LearnTop.Modules.Categories.Application.Abstractions.Data;
using LearnTop.Modules.Categories.Domain.Categories.Errors;
using LearnTop.Modules.Categories.Domain.Categories.Models;
using LearnTop.Modules.Categories.Domain.Categories.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Categories.Application.Categories.Features.Commands.AddChildCategory;

internal sealed class AddChildCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<AddChildCategoryCommand, AddChildCategoryResponse>
{

    public async Task<Result<AddChildCategoryResponse>> Handle(
        AddChildCategoryCommand request, 
        CancellationToken cancellationToken)
    {
        Category? category = await categoryRepository.GetAsync(request.CategoryId, cancellationToken);
        if (category is null)
        {
            return Result.Failure<AddChildCategoryResponse>(CategoryErrors.NotFound);
        }
        
        Category? childCategory = await categoryRepository.GetAsync(request.ChildCategoryId, cancellationToken);
        if (childCategory is null)
        {
            return Result.Failure<AddChildCategoryResponse>(CategoryErrors.NotFound);
        }
        
        Result<CategoryRelation> categoryRelationResult = CategoryRelation.Create(category.Id, childCategory.Id);
        if (categoryRelationResult.IsFailure)
        {
            return Result.Failure<AddChildCategoryResponse>(categoryRelationResult.Error);
        }
        
        Result result = category.AddChildCategory(categoryRelationResult.Value);
        if (result.IsFailure)
        {
            return Result.Failure<AddChildCategoryResponse>(result.Error);
        }
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new AddChildCategoryResponse();
    }
}
