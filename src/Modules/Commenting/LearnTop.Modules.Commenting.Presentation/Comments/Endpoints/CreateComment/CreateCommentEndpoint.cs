using LearnTop.Modules.Commenting.Application.Comments.Features.Commands.CreateComment;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Commenting.Presentation.Comments.Endpoints.CreateComment;

internal sealed class CreateCommentEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Comments", async (CreateCommentCommand command, ISender sender) =>
        {
            Result<CreateCommentResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Comments);
    }
}
