using LearnTop.Modules.Identity.Application.Users.Features.Queries.GetUserById;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Identity.Presentation.Users.GetUserById;

internal sealed class GetUserFullNameById : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Identity/User/FullName/{userId:guid}", async (Guid userId, ISender sender) =>
            {
                Result<GetUserByIdQuery.Response> result = await sender.Send(new GetUserByIdQuery(userId));
                if (result.IsFailure)
                {
                    return ApiResults.Problem(result);
                }
                return Results.Ok(result.Value.User.Username);
            })
            .WithTags(Tags.Identity);
    }
}
