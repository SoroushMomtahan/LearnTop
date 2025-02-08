using LearnTop.Modules.Identity.Application.Abstractions.Data;
using LearnTop.Modules.Identity.Application.Users.Services;
using LearnTop.Modules.Identity.Domain.Users.Models;
using LearnTop.Modules.Identity.Domain.Users.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Identity.Application.Users.Features.Commands.SignUpWithMobile;

internal sealed class SignUpWithMobileCommandHandler(
    IPasswordHasher passwordHasher,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<SignUpWithMobileCommand, SignUpWithMobileResponse>
{

    public async Task<Result<SignUpWithMobileResponse>> Handle(SignUpWithMobileCommand request, CancellationToken cancellationToken)
    {
        string passwordHash = passwordHasher.Hash(request.Password);
        Result<User> result = User.SignUpWithMobileNumber(request.Mobile, passwordHash);
        await userRepository.CreateAsync(result.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new SignUpWithMobileResponse(result.Value.Id);
    }
}
