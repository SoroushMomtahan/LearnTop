using LearnTop.Modules.Users.Application.Users.Features.Queries.GetUserById;

namespace LearnTop.Modules.Users.Presentation.Users.GetUserById;

internal sealed class GetUserFullNameById : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/User-FullName/{userId:guid}", async (Guid userId, ISender sender) =>
        {
            Result<GetUserByIdResponse> result = await sender.Send(new GetUserByIdQuery(userId));
            if (result.IsFailure)
            {
                return ApiResults.Problem(result);
            }
            return result.Match(Results.Ok, ApiResults.Problem);
        }).WithTags(Tags.Users);
    }
}
