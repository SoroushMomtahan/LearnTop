using LearnTop.Modules.Users.Application.Users.Features.Commands.CreateUser;

namespace LearnTop.Modules.Users.Presentation.Users.CreateUser;

internal sealed class CreateUserEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Register", static async (CreateUserCommand createUserCommand, ISender sender) =>
        {
            Result<CreateUserResponse> result = await sender.Send(createUserCommand);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Users);
    }
}
