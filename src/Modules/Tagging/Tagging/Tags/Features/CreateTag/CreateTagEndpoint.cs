using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Tagging.Tags.Features.CreateTag;

public sealed class CreateTagEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Tags", async (CreateTagCommand createTagCommand, ISender sender) =>
        {
            Result<CreateTagResponse> result = await sender.Send(createTagCommand);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(EndpointTags.Tag);
    }
}
