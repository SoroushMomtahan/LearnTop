using LearnTop.Modules.Commenting.Application.Comments.Features.Commands.DeleteComment;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Commenting.Presentation.Comments.Endpoints.DeleteComment;

internal sealed class DeleteCommentEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/Comments", async ([AsParameters]DeleteCommentCommand command, ISender sender) =>
        {
            Result<DeleteCommentResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Comments);
    }
}
