using LearnTop.Modules.Users.Domain.Users.Errors;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;
using Microsoft.AspNetCore.Identity;

namespace LearnTop.Modules.Users.Application.Users.Features.Commands.SendConfirmationEmail;

internal sealed class SendConfirmationEmailCommandHandler(UserManager<IdentityUser> userManager)
    : ICommandHandler<SendConfirmationEmailCommand, SendConfirmationEmailResponse>
{

    public async Task<Result<SendConfirmationEmailResponse>> Handle(
        SendConfirmationEmailCommand request, 
        CancellationToken cancellationToken)
    {
        IdentityUser? identityUser = await userManager.FindByEmailAsync(request.Email);
        if (identityUser is null)
        {
            return Result.Failure<SendConfirmationEmailResponse>(
                UserErrors.EmailNotFound(request.Email)
                );
        }
        string token = await userManager.GenerateEmailConfirmationTokenAsync(identityUser);
        
        // TODO: Send Token With Email Provider
        Console.WriteLine(token);

        return new SendConfirmationEmailResponse();
    }
}
