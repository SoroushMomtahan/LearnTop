using LearnTop.Modules.Commenting.Application.Comments.Features.Commands.EditComment;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Commenting.Presentation.Comments.Endpoints.EditComment;

internal sealed class EditCommentEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/Comments", async (EditCommentCommand command, ISender sender) =>
        {
            Result<EditCommentResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem); 
        })
        .WithTags(Tags.Comments);
    }
}
