using LearnTop.Modules.Users.Application.Users.Features.Queries.SignIn;

namespace LearnTop.Modules.Users.Presentation.Users.SignIn;

internal sealed class SignInEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/SignIn", async ([AsParameters] SignInQuery query, ISender sender) =>
        {
            Result<SignInResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Users);
    }
}
