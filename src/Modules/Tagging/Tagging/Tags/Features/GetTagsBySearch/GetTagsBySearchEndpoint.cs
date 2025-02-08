using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Tagging.Tags.Features.GetTagsBySearch;

public class GetTagsBySearchEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Tags/Contains", async (string searchString, ISender sender) =>
        {
            Result<GetTagsBySearchResponse> result = await sender.Send(new GetTagsBySearchQuery(new(), searchString));
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(EndpointTags.Tag)
        .RequireAuthorization();
    }
}
