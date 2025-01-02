using LearnTop.Modules.Users.Application.Users.Features.Queries.ConfirmEmail;

namespace LearnTop.Modules.Users.Presentation.Users.ConfirmEmail;

internal sealed class ConfirmEmailEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("Users/ConfirmEmail", async ([AsParameters] ConfirmEmailQuery query, ISender sender) =>
            {
                Result<ConfirmEmailResponse> result = await sender.Send(query);
                return result.Match(Results.Ok, ApiResults.Problem);
            })
        .WithTags(Tags.Users);
    }
}
