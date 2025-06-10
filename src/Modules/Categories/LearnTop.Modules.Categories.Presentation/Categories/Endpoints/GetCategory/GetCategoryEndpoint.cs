using LearnTop.Modules.Categories.Application.Categories.Features.Queries.GetCategory;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Categories.Presentation.Categories.Endpoints.GetCategory;

public class GetCategoryEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/category/{categoryId:guid}", async ([FromRoute]Guid categoryId, ISender sender) =>
        {
            Result<GetCategoryQuery.Response> result = await sender.Send(new GetCategoryQuery(categoryId));
            return result.Match(Results.Ok, ApiResults.Problem); 
        })
        .WithTags(Tags.Categories);
    }
}
