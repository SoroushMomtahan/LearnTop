using LearnTop.Modules.Users.Application.Users.Features.Queries.GetUserById;

namespace LearnTop.Modules.Users.Presentation.Users.GetUserById;

internal sealed class GetUserByIdEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/User/{userId:guid}", async (Guid userId, ISender sender) =>
        {
            Result<GetUserByIdResponse> result = await sender.Send(new GetUserByIdQuery(userId));
            return result.Match(Results.Ok, ApiResults.Problem);
        }).WithTags(Tags.Users);
    }
}
