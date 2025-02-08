using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Tagging.Tags.Features.DeleteTag;

internal sealed class DeleteTagEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/Tags", async ([AsParameters] DeleteTagCommand command, ISender sender) =>
        {
            Result<DeleteTagResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(EndpointTags.Tag)
        .RequireAuthorization(Permissions.DeleteTag);
    }
}
