using LearnTop.Modules.Categories.Application.Categories.Dtos;
using LearnTop.Modules.Categories.Domain.Categories.Models;
using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Categories.Application.Categories.Features.Queries.GetCategory;

public record GetCategoryQuery(Guid CategoryId) : IQuery<GetCategoryQuery.Response>
{
    public record Response(CategoryDto CategoryDto);
}
