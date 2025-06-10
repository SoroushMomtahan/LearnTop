using LearnTop.Modules.Categories.Application.Categories.Dtos;
using LearnTop.Modules.Categories.Domain.Categories.Models;
using LearnTop.Modules.Categories.Domain.Categories.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Categories.Application.Categories.Features.Queries.GetCategories;

internal sealed class GetCategoriesQueryHandler(
    ICategoryRepository categoryRepository) : IQueryHandler<GetCategoriesQuery, GetCategoriesQuery.Response>
{

    public async Task<Result<GetCategoriesQuery.Response>> Handle(
        GetCategoriesQuery request, 
        CancellationToken cancellationToken)
    {
        List<Category> categories = await categoryRepository.GetAllAsync(cancellationToken);
        List<CategoryDto> categoryDtos = categories.ConvertAll(input =>
        {
            return new CategoryDto()
            {
                Id = input.Id,
                Order = input.Order,
                Name = input.Name,
                Description = input.Description,
                LightImage = input.LightImage,
                DarkImage = input.DarkImage,
                Icon = input.Icon,
                ParentCategories = [.. input.ParentCategories.Select(x => x.ParentCategoryId)],
                ChildCategories = [.. input.ChildCategories.Select(x => x.ChildCategoryId)],
            };
        });
        return new GetCategoriesQuery.Response(categoryDtos);
    }
}
