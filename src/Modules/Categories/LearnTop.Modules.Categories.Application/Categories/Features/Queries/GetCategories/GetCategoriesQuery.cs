using LearnTop.Modules.Categories.Application.Categories.Dtos;
using LearnTop.Modules.Categories.Application.Categories.Features.Queries.GetCategory;
using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Categories.Application.Categories.Features.Queries.GetCategories;

public record GetCategoriesQuery : IQuery<GetCategoriesQuery.Response>
{
    public record Response(List<CategoryDto> Categories);
}
