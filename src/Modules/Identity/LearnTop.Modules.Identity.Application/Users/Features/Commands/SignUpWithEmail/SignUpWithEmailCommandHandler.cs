using LearnTop.Modules.Identity.Application.Abstractions.Data;
using LearnTop.Modules.Identity.Application.Users.Services;
using LearnTop.Modules.Identity.Domain.Users.Models;
using LearnTop.Modules.Identity.Domain.Users.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Identity.Application.Users.Features.Commands.SignUpWithEmail;

internal sealed class SignUpWithEmailCommandHandler(
    IPasswordHasher passwordHasher,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<SignUpWithEmailCommand, SignUpWithEmailResponse>
{

    public async Task<Result<SignUpWithEmailResponse>> Handle(SignUpWithEmailCommand request, CancellationToken cancellationToken)
    {
        string passwordHash = passwordHasher.Hash(request.Password);
        Result<User> result = User.SignUpWithEmail(request.Email, passwordHash);
        await userRepository.CreateAsync(result.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new SignUpWithEmailResponse(result.Value.Id);
    }
}
