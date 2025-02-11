using System.Security.Claims;
using LearnTop.Modules.Commenting.Application.Comments.Features.Commands.DeleteComment;
using LearnTop.Modules.Commenting.Application.Comments.Features.Queries.GetComment;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Commenting.Presentation.Comments.Endpoints.DeleteOwnComment;

internal sealed class DeleteOwnCommentEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/Comments/DeleteOwnComment", async (
            [AsParameters] DeleteCommentCommand command,
            ISender sender,
            ClaimsPrincipal user) =>
        {
            string? userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Results.Unauthorized();
            }
            Result<GetCommentResponse> currentCommentResult = await sender.Send(new GetCommentQuery(command.CommentId));
            if (currentCommentResult.IsFailure)
            {
                return ApiResults.Problem(currentCommentResult);
            }
            if (currentCommentResult.Value.CommentDto.CommenterId != Guid.Parse(userId))
            {
                return Results.Unauthorized();
            }
            Result<DeleteCommentResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Comments);
    }
}
