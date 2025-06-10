using LearnTop.Modules.Categories.Application.Categories.Dtos;
using LearnTop.Modules.Categories.Domain.Categories.Errors;
using LearnTop.Modules.Categories.Domain.Categories.Models;
using LearnTop.Modules.Categories.Domain.Categories.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Categories.Application.Categories.Features.Queries.GetCategory;

internal sealed class GetCategoryQueryHandler(
    ICategoryRepository categoryRepository) : IQueryHandler<GetCategoryQuery, GetCategoryQuery.Response>
{

    public async Task<Result<GetCategoryQuery.Response>> Handle(
        GetCategoryQuery request, 
        CancellationToken cancellationToken)
    {
        Category? category = await categoryRepository.GetAsync(request.CategoryId, cancellationToken);
        if (category is null)
        {
            return Result.Failure<GetCategoryQuery.Response>(CategoryErrors.NotFound);
        }
        CategoryDto categoryDto = MapToCategoryDto(category);
        return new GetCategoryQuery.Response(categoryDto);
    }

    private static CategoryDto MapToCategoryDto(Category category)
    {
        return new()
        {
            Id = category.Id,
            Order = category.Order,
            Name = category.Name,
            Description = category.Description,
            LightImage = category.LightImage,
            DarkImage = category.DarkImage,
            Icon = category.Icon,
            ParentCategories = [.. category.ParentCategories.Select(x=>x.ParentCategoryId)],
            ChildCategories = [.. category.ChildCategories.Select(x=>x.ChildCategoryId)],
        };
    }
}
