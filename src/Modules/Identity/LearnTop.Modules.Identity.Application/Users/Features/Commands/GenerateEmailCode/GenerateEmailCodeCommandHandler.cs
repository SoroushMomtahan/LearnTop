using LearnTop.Modules.Identity.Application.Abstractions.Data;
using LearnTop.Modules.Identity.Application.Users.Services;
using LearnTop.Modules.Identity.Domain.Users.Errors;
using LearnTop.Modules.Identity.Domain.Users.Models;
using LearnTop.Modules.Identity.Domain.Users.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Identity.Application.Users.Features.Commands.GenerateEmailCode;

internal sealed class GenerateEmailCodeCommandHandler(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    IEmailService emailService)
    : ICommandHandler<GenerateEmailCodeCommand, GenerateEmailCodeResponse>
{

    public async Task<Result<GenerateEmailCodeResponse>> Handle(GenerateEmailCodeCommand request, CancellationToken cancellationToken)
    {
        User? user = await userRepository.GetUserAsync(request.Email, cancellationToken);
        if (user is null)
        {
            return Result.Failure<GenerateEmailCodeResponse>(UserErrors.NotFound);
        }
        if (user.Email.Verify.Status)
        {
            return Result.Failure<GenerateEmailCodeResponse>(UserErrors.AlreadyVerified);
        }
        var random = new Random();
        user.Email.SetVerifyCode(random.Next(1000, 10000));
        await emailService.SendEmailAsync(request.Email, "", $"{user.Email.Verify.Code}");
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new GenerateEmailCodeResponse(true);
    }
}
