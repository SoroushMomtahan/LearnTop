using LearnTop.Modules.Users.Application.Users.Features.Commands.SendConfirmationEmail;

namespace LearnTop.Modules.Users.Presentation.Users.SendConfirmationEmail;

internal sealed class SendConfirmationEmailEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/ConfirmationEmail", async (
                [AsParameters] SendConfirmationEmailCommand command,
                ISender sender) =>
            {
                Result<SendConfirmationEmailResponse> result = await sender.Send(command);
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Users);
    }
}
