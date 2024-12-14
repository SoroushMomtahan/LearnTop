using LearnTop.Modules.Users.Application.Abstractions.Data;
using LearnTop.Modules.Users.Domain.Users.Models;
using LearnTop.Modules.Users.Domain.Users.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Users.Application.Users.Commands;

public class CreateUserCommandHandler
    (IUserRepository userRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateUserCommand, CreateUserCommandResponse>
{

    public async Task<Result<CreateUserCommandResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Result<User> result = User.Create(
            request.Firstname,
            request.Lastname,
            request.Email,
            request.Password);

        if (!result.IsSuccess)
        {
            return Result.Failure<CreateUserCommandResponse>(result.Error);
        }
        await userRepository.AddAsync(result.Value);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new CreateUserCommandResponse(result.Value.Id);
    }
}
