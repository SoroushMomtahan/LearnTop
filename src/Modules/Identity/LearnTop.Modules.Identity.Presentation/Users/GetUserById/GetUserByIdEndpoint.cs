using LearnTop.Modules.Identity.Application.Users.Features.Queries.GetUserById;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Identity.Presentation.Users.GetUserById;

internal sealed class GetUserByIdEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Identity/User/{userId:guid}", async (Guid userId, ISender sender) =>
            {
                Result<GetUserByIdQuery.Response> result = await sender.Send(new GetUserByIdQuery(userId));
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Identity);
    }
}
