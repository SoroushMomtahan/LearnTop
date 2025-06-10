using LearnTop.Modules.Categories.Application.Categories.Dtos;
using LearnTop.Modules.Categories.Application.Categories.Features.Queries.GetCategories;
using LearnTop.Shared.Application.Caching;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Categories.Presentation.Categories.Endpoints.GetCategories;

internal sealed class GetCategoriesEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Category", async (ISender sender, ICacheService cacheService) =>
            {
                List<CategoryDto> categoryDtos = await cacheService.GetAsync<List<CategoryDto>>("Categories");
                if (categoryDtos is not null)
                {
                    return Results.Ok(new GetCategoriesQuery.Response(categoryDtos));
                }
                Result<GetCategoriesQuery.Response> result = await sender.Send(new GetCategoriesQuery());
                await cacheService.SetAsync("Categories", result.Value.Categories, TimeSpan.FromDays(30));
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Categories);
    }
}
