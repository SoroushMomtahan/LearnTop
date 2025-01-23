using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Tagging.Tags.Features.GetTagById;

internal sealed class GetTagByIdEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Tags", async ([AsParameters] GetTagByIdQuery query, ISender sender) =>
        {
            Result<GetTagByIdResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem); 
        });
    }
}
